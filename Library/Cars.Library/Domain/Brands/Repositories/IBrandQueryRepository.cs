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

        /// <summary>
        /// Retorna la información de la marca dado el nombre
        /// </summary>
        /// <param name="name">Nombre de la marca</param>
        /// <returns>Información de la marca</returns>
        Task<BrandModel> GetByName(string name);
    }
}