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
            public async Task<int> Handle(Request request, CancellationToken cancellationToken)
            {
                int response = 0;

                BrandInfo brand = await BrandRepository.GetByName(request.Name);

                if (brand == null)
                {
                    brand = new BrandInfo
                    {
                        Name = request.Name
                    };

                    await BrandRepository.Create(brand);
                    response = brand.Id;
                }
                else
                {
                    throw new InvalidOperationException("DuplicateObject");
                }

                return response;
            }
        }

        public class Request : IRequest<int>
        {
            public string Name { get; set; }
        }
    }
}