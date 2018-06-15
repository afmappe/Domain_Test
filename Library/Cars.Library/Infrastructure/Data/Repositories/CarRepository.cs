using Cars.Library.Domain.Cars;
using Cars.Library.Domain.Cars.Repositories;
using Cars.Library.Infrastructure.Data.Context;
using System.Data.Entity.Infrastructure;

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
        /// <param name="contextFactory"></param>
        public CarRepository(IDbContextFactory<CarsContext> contextFactory)
            : base(contextFactory)
        { }
    }
}