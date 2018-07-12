using Cars.Library.Domain.Models;
using Cars.Library.Domain.Models.Models;
using Cars.Library.Domain.Models.Repositories;
using Cars.Library.Infrastructure.Data.Context;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Library.Infrastructure.Data.Repositories
{
    internal class CarModelRepository : AsyncRepositoryBase<ModelInfo, CarsContext>
          , ICarModelRepository
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public CarModelRepository(CarsContext context)
            : base(context)
        { }

        public IQueryable<CarModelModel> CarModelQuery(CarsContext context)
        {
            return from model in context.Model
                   from brand in context.Brand.Where(b => b.Id == model.BrandId)
                   select new CarModelModel
                   {
                       BrandId = brand.Id,
                       BrandName = brand.Name,
                       Id = model.Id,
                       Name = model.Name
                   };
        }

        /// <summary>
        /// Implementación de <see cref="ICarModelRepository.Get(int, string)"/>
        /// </summary>
        public async Task<CarModelModel> Get(int brandId, string name)
        {
            CarModelModel result = null;

            try
            {
                var query = from model in CarModelQuery(Context)
                            where
                                model.BrandId == brandId &&
                                model.Name == name
                            select model;

                result = await query.SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }
    }
}