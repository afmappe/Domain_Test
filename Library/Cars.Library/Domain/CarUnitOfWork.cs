using Cars.Library.Infrastructure.Data;
using Cars.Library.Infrastructure.Data.Context;
using Cars.Library.Infrastructure.Data.Interfaces;

namespace Cars.Library.Domain
{
    /// <summary>
    /// Marca el UnitOfWork del dominio
    /// </summary>
    public interface ICarUnitOfWork : IUnitOfWork
    {
    }

    /// <summary>
    /// UnitOfWork del dominio
    /// </summary>
    public class CarUnitOfWork : UnitOfWork<CarsContext>, ICarUnitOfWork
    {
        #region Constructor

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public CarUnitOfWork(CarsContext context)
            : base(context)
        { }

        #endregion
    }
}