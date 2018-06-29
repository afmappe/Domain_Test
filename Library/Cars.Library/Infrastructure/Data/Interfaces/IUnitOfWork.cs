using System;

namespace Cars.Library.Infrastructure.Data.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Hace commit de los cambios
        /// </summary>
        void Commit();

        /// <summary>
        /// Descarta todos los cambios sobre los que no se ha hecho commit
        /// </summary>
        void RejectChanges();
    }
}