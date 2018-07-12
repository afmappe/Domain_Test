using Cars.Library.Domain.Brands.Commands;
using Cars.Library.Domain.Cars.Models;
using Cars.Library.Domain.Cars.Repositories;
using Cars.Library.Domain.Models.Commands;
using Cars.Library.Infrastructure.Data.Interfaces;
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
        public class Handler : IRequestHandler<Request, int>
        {
            #region Dependencias

            /// <summary>
            /// <see cref="ICarRepository"/>
            /// </summary>
            private readonly ICarRepository _CarRepository;

            /// <summary>
            /// <see cref="ICarUnitOfWorkFactory"/>
            /// </summary>
            private readonly ICarUnitOfWorkFactory _CarUnitOfWorkFactory;

            /// <summary>
            /// <see cref="IMediator"/>
            /// </summary>
            private readonly IMediator _Mediator;

            #endregion

            /// <summary>
            /// Constructor por defecto
            /// </summary>
            public Handler(ICarRepository CarRepository, ICarUnitOfWorkFactory CarUnitOfWorkFactory, IMediator Mediator)
            {
                _CarRepository = CarRepository;
                _CarUnitOfWorkFactory = CarUnitOfWorkFactory;
                _Mediator = Mediator;
            }

            /// <summary>
            /// Implementación de <see cref="IRequestHandler{TRequest, TResponse}.Handle(TRequest, CancellationToken)"/>
            /// </summary>
            public async Task<int> Handle(Request request, CancellationToken cancellationToken)
            {
                CarInfo car = await _CarRepository.Get(request.License);

                car = car ?? new CarInfo();
                car.Image = request.Image;
                car.IsAvailable = request.IsAvailable;
                car.IsNew = request.IsNew;
                car.License = request.License;
                car.ModelId = request.ModelId;
                car.Year = request.Year;

                using (IUnitOfWork context = _CarUnitOfWorkFactory.Create())
                {
                    if (car.ModelId == 0)
                    {
                        int brandId = await _Mediator.Send(new CreateBrandCommand.Request { Name = request.BrandName });
                        int modelId = await _Mediator.Send(new CreateCarModelCommand.Request { BrandId = brandId, Name = request.ModelName });

                        car.ModelId = modelId;
                    }

                    if (car.Id == 0)
                    {
                        await _CarRepository.Create(car);
                    }
                    else
                    {
                        await _CarRepository.Update(car);
                    }

                    await _CarRepository.Save();
                    context.Commit();
                }
                return car.Id;
            }
        }

        public class Request : CarModel, IRequest<int> { }
    }
}