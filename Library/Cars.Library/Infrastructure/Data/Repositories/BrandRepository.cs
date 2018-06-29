using Cars.Library.Domain.Brands;
using Cars.Library.Domain.Brands.Repositories;
using Cars.Library.Infrastructure.Data.Context;
using System.Data.Entity.Infrastructure;

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
        /// <param name="contextFactory"></param>
        public BrandRepository(IDbContextFactory<CarsContext> contextFactory)
            : base(contextFactory)
        { }
    }
}