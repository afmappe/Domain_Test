using Cars.Library.Domain.Brands;
using Cars.Library.Domain.Brands.Models;
using Cars.Library.Domain.Brands.Repositories;
using Cars.Library.Infrastructure.Data.Context;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Library.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Implementación de <see cref="ICarRepository"/>
    /// </summary>
    internal class BrandRepository : AsyncRepositoryBase<BrandInfo, CarsContext>
        , IBrandRepository
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public BrandRepository(CarsContext context)
            : base(context)
        { }

        /// <summary>
        /// Implementación de <see cref="IBrandRepository.GetByName(string)"/>
        /// </summary>
        public async Task<BrandModel> GetByName(string name)
        {
            BrandModel result;
            try
            {
                var query = from brand in Context.Brand
                            where
                                brand.Name == name
                            select new BrandModel
                            {
                                Id = brand.Id,
                                Name = brand.Name
                            };

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