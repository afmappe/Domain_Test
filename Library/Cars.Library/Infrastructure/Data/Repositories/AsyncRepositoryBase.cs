using Cars.Library.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Library.Infrastructure.Data.Repositories
{
    public abstract class AsyncRepositoryBase<TEntityType, TContextType> :
        IAsyncRepository<TEntityType>
        where TEntityType : class
        where TContextType : DbContext
    {
        private readonly IDbContextFactory<TContextType> ContextFactory;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        protected AsyncRepositoryBase(IDbContextFactory<TContextType> contextFactory)
        {
            ContextFactory = contextFactory;
        }

        /// <summary>
        /// Implementación de <see cref="IAsyncRepository{TEntityType}.Create(TEntityType)"/>
        /// </summary>
        public virtual async Task Create(TEntityType record)
        {
            try
            {
                using (TContextType context = CreateContext())
                {
                    context.Entry(record).State = EntityState.Added;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Implementación de <see cref="IAsyncRepository{TEntityType}.Create(IEnumerable{TEntityType})"/>
        /// </summary>
        public virtual async Task Create(IEnumerable<TEntityType> list)
        {
            try
            {
                using (TContextType context = CreateContext())
                {
                    if (list != null && list.Any())
                    {
                        context.Configuration.AutoDetectChangesEnabled = false;
                        context.Set<TEntityType>().AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public Task Delete(TEntityType record)
        {
            throw new NotImplementedException();
        }

        public Task Delete(IEnumerable<TEntityType> list)
        {
            throw new NotImplementedException();
        }

        public Task Find(params object[] keys)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntityType record)
        {
            throw new NotImplementedException();
        }

        public Task Update(IEnumerable<TEntityType> list)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Constructor del contexto
        /// </summary>
        /// <returns>Contexto</returns>
        protected virtual TContextType CreateContext()
        {
            return ContextFactory.Create();
        }
    }
}