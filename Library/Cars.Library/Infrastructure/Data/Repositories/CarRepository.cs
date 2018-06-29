using Cars.Library.Domain.Cars;
using Cars.Library.Domain.Cars.Repositories;
using Cars.Library.Infrastructure.Data.Context;

namespace Cars.Library.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Implementación de <see cref="ICarRepository"/>
    /// </summary>
    internal class CarRepository : AsyncRepositoryBase<CarInfo, CarsContext>
        , ICarRepository
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public CarRepository(CarsContext context)
            : base(context)
        { }
    }
}