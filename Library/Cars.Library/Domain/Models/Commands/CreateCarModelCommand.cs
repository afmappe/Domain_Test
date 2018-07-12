// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using Cars.Library.Domain.Models.Models;
using Cars.Library.Domain.Models.Repositories;
using Cars.Library.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cars.Library.Domain.Models.Commands
{
    /// <summary>
    ///
    /// </summary>
    public static class CreateCarModelCommand
    {
        /// <summary>
        /// <see cref="IRequestHandler{TRequest, TResponse}"/>
        /// </summary>
        public class Handler : IRequestHandler<Request, int>
        {
            /// <summary>
            /// <see cref="ICarModelRepository"/>
            /// </summary>
            private readonly ICarModelRepository _CarModelRepository;

            /// <summary>
            /// Constructor por defecto
            /// </summary>
            public Handler(ICarModelRepository CarModelRepository)
            {
                _CarModelRepository = CarModelRepository;
            }

            /// <summary>
            /// Implementación de <see cref="IRequestHandler{TRequest, TResponse}.Handle(TRequest, CancellationToken)"/>
            /// </summary>
            public async Task<int> Handle(Request request, CancellationToken cancellationToken)
            {
                int response = 0;

                try
                {
                    CarModelModel model = await _CarModelRepository.Get(request.BrandId, request.Name);

                    if (model == null)
                    {
                        ModelInfo info = new ModelInfo
                        {
                            BrandId = request.BrandId,
                            Name = request.Name
                        };
                        await _CarModelRepository.Create(info);
                        await _CarModelRepository.Save();
                        response = info.Id;
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

        /// <summary>
        ///
        /// </summary>
        public class Request : CarModelModel, IRequest<int>
        {
        }
    }
}