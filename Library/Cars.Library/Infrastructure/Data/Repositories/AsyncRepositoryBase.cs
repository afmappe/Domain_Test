using Cars.Library.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Library.Infrastructure.Data.Repositories
{
    public abstract class AsyncRepositoryBase<TEntityType, TContextType> :
        IAsyncRepository<TEntityType>
        where TEntityType : class
        where TContextType : DbContext
    {
        protected readonly TContextType Context;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        protected AsyncRepositoryBase(TContextType context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Implementación de <see cref="IAsyncRepository{TEntityType}.Create(TEntityType)"/>
        /// </summary>
        public virtual async Task Create(TEntityType record)
        {
            try
            {
                Context.Entry(record).State = EntityState.Added;
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
                if (list != null && list.Any())
                {
                    Context.Configuration.AutoDetectChangesEnabled = false;
                    Context.Set<TEntityType>().AddRange(list);
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

        /// <summary>
        /// Implementación de <see cref="IAsyncRepository{TEntityType}.Find(object[])"/>
        /// </summary>
        public async Task<TEntityType> Find(params object[] keys)
        {
            TEntityType record = default(TEntityType);
            try
            {
                record = await Context.Set<TEntityType>().FindAsync(keys);
            }
            catch (Exception ex)
            {
            }
            return record;
        }

        /// <summary>
        /// Implementación de <see cref="IAsyncRepository{TEntityType}.Save"/>
        /// </summary>
        public Task Save()
        {
            return Context.SaveChangesAsync();
        }

        public async Task Update(TEntityType record)
        {
            Context.Entry(record).State = EntityState.Modified;
        }

        public async Task Update(IEnumerable<TEntityType> list)
        {
            if (list != null && list.Any())
            {
                Context.Configuration.AutoDetectChangesEnabled = false;

                foreach (TEntityType record in list)
                {
                    Context.Entry(record).State = EntityState.Modified;
                }
                Context.ChangeTracker.DetectChanges();
            }
        }
    }
}