using Cars.Library.Infrastructure.Data.Context;

namespace Cars.Library.Infrastructure.Data
{
    /// <summary>
    /// Constructor por defecto
    /// </summary>
    public class CarUnitOfWork : UnitOfWork<CarsContext>
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