﻿using Cars.Library.Domain.Brands.Models;
using Cars.Library.Domain.Brands.Repositories;
using Cars.Library.Exceptions;
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

                try
                {
                    BrandModel model = await _BrandRepository.GetByName(request.Name);

                    if (model == null)
                    {
                        BrandInfo brand = new BrandInfo
                        {
                            Name = request.Name
                        };

                        await _BrandRepository.Create(brand);
                        await _BrandRepository.Save();
                        response = brand.Id;
                    }
                    else
                    {
                        response = model.Id;
                    }
                }
                catch (Exception ex)
                {
                    CommandExceptionHandler.Handle(ex, request);
                }

                return response;
            }
        }

        public class Request : BrandModel, IRequest<int>
        {
        }
    }
}