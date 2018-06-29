using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Cars.Library.Infrastructure.Data.Repositories
{
    internal class QueryRepository<TContextType>
        where TContextType : DbContext
    {
        private readonly IDbContextFactory<TContextType> ContextFactory;

        public QueryRepository(IDbContextFactory<TContextType> contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public TContextType CreateContext()
        {
            return ContextFactory.Create();
        }
    }
}