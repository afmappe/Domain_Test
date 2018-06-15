using Cars.Library.Domain.Cars.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cars.Library.Domain.Cars.Commands
{
    public static class CreateCarCommand
    {
        /// <summary>
        /// Implementación de <see cref="IRequestHandler{TRequest, TResponse}"/>
        /// </summary>
        public class Handler : IRequestHandler<Request, Response>
        {
            #region Dependencias

            private readonly ICarRepository CarRepository;

            #endregion

            /// <summary>
            /// Constructor por defecto
            /// </summary>
            public Handler(ICarRepository carRepository)
            {
                CarRepository = carRepository;
            }

            /// <summary>
            /// Implementación de <see cref="IRequestHandler{TRequest, TResponse}.Handle(TRequest, CancellationToken)"/>
            /// </summary>
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                Response result = null;
                try
                {
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }
        }

        public class Request : IRequest<Response> { }

        public class Response { }
    }
}