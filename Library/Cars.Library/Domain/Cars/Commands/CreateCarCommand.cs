using Cars.Library.Domain.Cars.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cars.Library.Domain.Cars.Commands
{
    public static class CreateCarCommand
    {
        /// <summary>
        /// Implementación de <see cref="IRequestHandler{TRequest, TResponse}"/>
        /// </summary>
        public class Handler : IRequestHandler<Request, CarInfo>
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
            public async Task<CarInfo> Handle(Request request, CancellationToken cancellationToken)
            {
                CarRepository.Create(request);
                return request;
            }
        }

        public class Request : CarInfo, IRequest<CarInfo> { }
    }
}