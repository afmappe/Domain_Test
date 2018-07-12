using Cars.Library.Domain.Models.Models;
using Cars.Library.Infrastructure.Data.Interfaces;
using System.Threading.Tasks;

namespace Cars.Library.Domain.Models.Repositories
{
    /// <summary>
    ///
    /// </summary>
    public interface ICarModelRepository : IAsyncRepository<ModelInfo>
    {
        /// <summary>
        /// Obtiene un modelo a partir de la restricción única
        /// </summary>
        /// <param name="brandId">Identificador de la marca</param>
        /// <param name="name">Nombre del modelo</param>
        /// <returns>Información Modelo</returns>
        Task<CarModelModel> Get(int brandId, string name);
    }
}