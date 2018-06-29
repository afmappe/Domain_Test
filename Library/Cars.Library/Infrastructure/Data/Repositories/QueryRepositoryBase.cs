using System.Data.Entity;

namespace Cars.Library.Infrastructure.Data.Repositories
{
    internal class QueryRepositoryBase<TContextType>
        where TContextType : DbContext
    {
        protected readonly TContextType context;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        protected QueryRepositoryBase(TContextType context)
        {
            this.context = context;
        }
    }
}