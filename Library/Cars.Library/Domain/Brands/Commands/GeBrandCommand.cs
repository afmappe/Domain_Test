using Cars.Library.Domain.Brands.Models;
using Cars.Library.Domain.Brands.Repositories;
using Cars.Library.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cars.Library.Domain.Brands.Commands
{
    /// <summary>
    ///
    /// </summary>
    public static class GeBrandCommand
    {
        /// <summary>
        /// Implementación de <see cref="IRequestHandler{TRequest, TResponse}"/>
        /// </summary>
        public class Handler : IRequestHandler<Request, BrandModel>
        {
            #region Dependencias

            private readonly IBrandQueryRepository BrandRepository;

            #endregion

            /// <summary>
            /// Constructor por defecto
            /// </summary>
            public Handler(IBrandQueryRepository brandRepository)
            {
                BrandRepository = brandRepository;
            }

            /// <summary>
            /// Implementación de <see cref="IRequestHandler{TRequest, TResponse}.Handle(TRequest, CancellationToken)"/>
            /// </summary>
            public async Task<BrandModel> Handle(Request request, CancellationToken cancellationToken)
            {
                BrandModel response = null;
                try
                {
                    response = await BrandRepository.Get(request.Id);
                }
                catch (Exception ex)
                {
                    CommandExceptionHandler.Handle(ex, request);
                }
                return response;
            }
        }

        public class Request : IRequest<BrandModel>
        {
            public int Id { get; set; }
        }
    }
}