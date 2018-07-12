using System.Data.Entity;

namespace Cars.Library.Infrastructure.Data.Repositories
{
    internal class QueryRepositoryBase<TContextType>
        where TContextType : DbContext
    {
        protected readonly TContextType Context;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        protected QueryRepositoryBase(TContextType context)
        {
            Context = context;
        }
    }
}