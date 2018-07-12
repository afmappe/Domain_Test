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
    }

    /// <summary>
    ///
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Crea las instancias de las unidades de trabajo
        /// </summary>
        /// <returns>UnitOfWork</returns>
        IUnitOfWork Create();
    }
}