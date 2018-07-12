using Cars.Library.Infrastructure.Common;
using Cars.Library.Infrastructure.Data.Interfaces;
using System;
using System.Data.Entity;

namespace Cars.Library.Infrastructure.Data
{
    public class UnitOfWork<TContextType> : Disposable, IUnitOfWork
            where TContextType : DbContext
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public UnitOfWork(TContextType context)
        {
            Transaction = context.Database.BeginTransaction();
        }

        protected DbContextTransaction Transaction { get; set; }

        /// <summary>
        /// Implementación de <see cref="IUnitOfWork.Commit"/>
        /// </summary>
        public void Commit()
        {
            try
            {
                Transaction.Commit();
            }
            catch (Exception)
            {
                Transaction.Rollback();
            }
        }

        /// <summary>
        /// Implementación de <see cref="Disposable.InternalDispose"/>
        /// </summary>
        protected override void InternalDispose()
        {
            Transaction.Dispose();
        }
    }
}