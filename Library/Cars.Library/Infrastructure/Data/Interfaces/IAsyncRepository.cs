using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Library.Infrastructure.Data.Interfaces
{
    /// <summary>
    /// Define las operaciones de los repositorios
    /// </summary>
    /// <typeparam name="TEntityType">Entidad</typeparam>
    public interface IAsyncRepository<TEntityType>
        where TEntityType : class
    {
        /// <summary>
        /// Crea una entidad en el contexto
        /// </summary>
        /// <param name="record">Entidad a crear</param>
        /// <returns>Entidad creado</returns>
        Task Create(TEntityType record);

        /// <summary>
        /// Crea una lista de entidades en el contexto
        /// </summary>
        /// <param name="list">Entidad a crear</param>
        /// <returns>Entidad creado</returns>
        Task Create(IEnumerable<TEntityType> list);

        /// <summary>
        /// Elimina una entidad del contexto
        /// </summary>
        /// <param name="record">Entidad a eliminar (no es necesario obtenerla previamente
        /// basta con establecer las propiedades que correspondan a las llaves primarias)</param>
        Task Delete(TEntityType record);

        /// <summary>
        /// Elimina un listado de entidades del contexto
        /// </summary>
        /// <param name="list">Entidades a eliminar</param>
        Task Delete(IEnumerable<TEntityType> list);

        /// <summary>
        ///
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        Task<TEntityType> Find(params object[] keys);

        /// <summary>
        /// Actualiza una entidad en el contexto
        /// </summary>
        /// <param name="record">Entidad a actualizar</param>
        /// <returns>Entidad actualizada</returns>
        Task Update(TEntityType record);

        /// <summary>
        /// Actualiza una lista de entidades
        /// </summary>
        /// <param name="list">Entidades a actualizar</param>
        /// <returns>Entidades actualizadas</returns>
        Task Update(IEnumerable<TEntityType> list);
    }
}