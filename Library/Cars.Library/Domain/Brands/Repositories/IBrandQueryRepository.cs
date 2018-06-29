using Cars.Library.Domain.Brands.Models;
using Cars.Library.Infrastructure.Data.Interfaces;
using System.Threading.Tasks;

namespace Cars.Library.Domain.Brands.Repositories
{
    /// <summary>
    ///
    /// </summary>
    public interface IBrandQueryRepository : IQueryRepository
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BrandModel> Get(int id);
    }
}