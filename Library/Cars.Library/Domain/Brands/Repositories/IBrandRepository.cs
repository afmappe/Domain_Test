using Cars.Library.Domain.Brands.Models;
using Cars.Library.Infrastructure.Data.Interfaces;
using System.Threading.Tasks;

namespace Cars.Library.Domain.Brands.Repositories
{
    public interface IBrandRepository
        : IAsyncRepository<BrandInfo>
    {
        /// <summary>
        /// Retorna la información de la marca dado el nombre
        /// </summary>
        /// <param name="name">Nombre de la marca</param>
        /// <returns>Información de la marca</returns>
        Task<BrandModel> GetByName(string name);
    }
}