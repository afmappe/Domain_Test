using Cars.Library.Domain.Cars.Models;
using Cars.Library.Extensions;
using Cars.Library.Infrastructure.Common.Entities;
using Cars.Library.Infrastructure.Data.Context;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Library.Infrastructure.Data.Repositories
{
    internal class CarQueryRepository : QueryRepositoryBase<CarsContext>
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public CarQueryRepository(CarsContext context)
            : base(context)
        { }

        public IQueryable<CarModel> CarModelQuery(CarsContext context)
        {
            return from car in context.Car
                   from model in context.Model.Where(m => m.Id == car.ModelId)
                   from brand in context.Brand.Where(b => b.Id == model.BrandId)
                   select new CarModel
                   {
                       BrandId = brand.Id,
                       BrandName = brand.Name,
                       Id = car.Id,
                       Image = car.Image,
                       IsAvailable = car.IsAvailable,
                       IsNew = car.IsNew,
                       License = car.License,
                       ModelId = model.Id,
                       ModelName = model.Name,
                       Year = car.Year
                   };
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<ListInfo<CarModel>> Search(CarSearch search)
        {
            ListInfo<CarModel> result = null;
            try
            {
                var query = from car in CarModelQuery(Context)
                            where (
                                !search.ModelIds.Any() ||
                                search.ModelIds.Any(x => x == car.ModelId)
                            ) && (
                                !search.Years.Any() ||
                                search.Years.Any(x => x == car.Year)
                            ) && (
                                string.IsNullOrEmpty(search.Search) ||
                                car.ModelName.Contains(search.Search) ||
                                car.BrandName.Contains(search.Search) ||
                                car.License.Contains(search.Search)
                            )
                            select car;

                result = new ListInfo<CarModel>
                {
                    Count = await query.CountAsync(),
                    Data = await query.Paginate(search).ToListAsync()
                };
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}