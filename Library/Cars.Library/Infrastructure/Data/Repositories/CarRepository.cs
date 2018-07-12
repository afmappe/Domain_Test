using Cars.Library.Domain.Cars;
using Cars.Library.Domain.Cars.Repositories;
using Cars.Library.Infrastructure.Data.Context;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

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

        public async Task<CarInfo> Get(string license)
        {
            CarInfo result = null;
            try
            {
                if (!string.IsNullOrEmpty(license))
                {
                    string search = license.ToLower();
                    result = await Context.Car
                        .SingleOrDefaultAsync(x => x.License.ToLower() == search);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}