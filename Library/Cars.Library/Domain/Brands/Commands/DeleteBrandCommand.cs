using Cars.Library.Domain.Brands.Repositories;
using Cars.Library.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cars.Library.Domain.Brands.Commands
{
    public static class DeleteBrandCommand
    {
        /// <summary>
        /// Implementación de <see cref="IRequestHandler{TRequest, TResponse}"/>
        /// </summary>
        public class Handler : IRequestHandler<Request>
        {
            #region Dependencias

            private readonly IBrandRepository BrandRepository;

            #endregion

            /// <summary>
            /// Constructor por defecto
            /// </summary>
            public Handler(IBrandRepository brandRepository)
            {
                BrandRepository = brandRepository;
            }

            /// <summary>
            /// Implementación de <see cref="IRequestHandler{TRequest, TResponse}.Handle(TRequest, CancellationToken)"/>
            /// </summary>
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                try
                {
                    if (request != null)
                    {
                        BrandInfo brand = new BrandInfo
                        {
                            Id = request.Id,
                            Name = request.Name
                        };

                        await BrandRepository.Delete(brand);
                    }
                }
                catch (Exception ex)
                {
                    CommandExceptionHandler.Handle(ex, request);
                }
                return Unit.Value;
            }
        }

        public class Request : IRequest<Unit>
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}