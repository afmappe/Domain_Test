using Cars.Library.Infrastructure.Common;
using Cars.Library.Infrastructure.Data.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

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
            Context = context;
        }

        /// <summary>
        /// Contexto de EntityFramework
        /// </summary>
        protected TContextType Context { get; set; }

        /// <summary>
        /// Implementación de <see cref="IUnitOfWork.Commit"/>
        /// </summary>
        public void Commit()
        {
            Context.SaveChangesAsync();
        }

        /// <summary>
        /// Implementación de <see cref="IUnitOfWork.Commit"/>
        /// </summary>
        public void RejectChanges()
        {
            foreach (DbEntityEntry entry in Context.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;

                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        /// <summary>
        /// Implementación de <see cref="Disposable.InternalDispose"/>
        /// </summary>
        protected override void InternalDispose()
        {
            Context.Dispose();
        }
    }
}