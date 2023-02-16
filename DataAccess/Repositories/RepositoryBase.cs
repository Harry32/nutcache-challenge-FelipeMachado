using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DataContext dataContext;

        public RepositoryBase(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await dataContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> Get(Guid id)
        {
            return await dataContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<bool> Insert(TEntity entity)
        {
            await dataContext.Set<TEntity>().AddAsync(entity);

            if(await dataContext.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            var id = entity.GetType().GetProperty("id").GetValue(entity) as Guid?;

            var entityDB = Get(id.Value).Result;

            if (entityDB != null)
            {
                dataContext.Set<TEntity>().Update(entity);
                await dataContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var entity = Get(id).Result;

            if (entity != null)
            {
                dataContext.Set<TEntity>().Remove(entity);
                await dataContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}