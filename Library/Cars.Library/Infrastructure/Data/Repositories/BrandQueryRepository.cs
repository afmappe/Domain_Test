using Cars.Library.Domain.Brands.Models;
using Cars.Library.Domain.Brands.Repositories;
using Cars.Library.Infrastructure.Data.Context;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Library.Infrastructure.Data.Repositories
{
    internal class BrandQueryRepository : QueryRepositoryBase<CarsContext>,
        IBrandQueryRepository
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        protected BrandQueryRepository(CarsContext context)
            : base(context)
        { }

        public static IQueryable<BrandModel> BrandModelQuery(CarsContext context)
        {
            return from brand in context.Brand
                   select new BrandModel
                   {
                       Id = brand.Id,
                       Name = brand.Name
                   };
        }

        /// <summary>
        /// Implementación de <see cref="IBrandQueryRepository.Get(int)"/>
        /// </summary>
        public async Task<BrandModel> Get(int id)
        {
            BrandModel result = null;
            try
            {
                var query = BrandModelQuery(context).Where(x => x.Id == id);
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