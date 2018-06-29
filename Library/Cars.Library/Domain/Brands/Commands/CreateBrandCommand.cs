using Cars.Library.Domain.Brands.Models;
using Cars.Library.Domain.Brands.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cars.Library.Domain.Brands.Commands
{
    public static class CreateBrandCommand
    {
        /// <summary>
        /// Implementación de <see cref="IRequestHandler{TRequest, TResponse}"/>
        /// </summary>
        public class Handler : IRequestHandler<Request, int>
        {
            #region Dependencias

            private readonly IBrandRepository _BrandRepository;

            #endregion

            /// <summary>
            /// Constructor por defecto
            /// </summary>
            public Handler(IBrandRepository BrandRepository)
            {
                _BrandRepository = BrandRepository;
            }

            /// <summary>
            /// Implementación de <see cref="IRequestHandler{TRequest, TResponse}.Handle(TRequest, CancellationToken)"/>
            /// </summary>
            public async Task<int> Handle(Request request, CancellationToken cancellationToken)
            {
                int response = 0;

                BrandModel model = await _BrandRepository.GetByName(request.Name);

                if (model == null)
                {
                    BrandInfo brand = new BrandInfo
                    {
                        Name = request.Name
                    };

                    await _BrandRepository.Create(brand);
                    response = brand.Id;
                }
                else
                {
                    throw new InvalidOperationException("DuplicateObject");
                }

                return response;
            }
        }

        public class Request : BrandModel, IRequest<int>
        {
        }
    }
}