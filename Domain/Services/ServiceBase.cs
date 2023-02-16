using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            return repository.GetAll();
        }

        public virtual Task<TEntity> Get(Guid id)
        {
            return repository.Get(id);
        }

        public virtual Task<bool> Insert(TEntity entity)
        {
            return repository.Insert(entity);
        }

        public virtual Task<bool> Update(TEntity entity)
        {
            return repository.Update(entity);
        }

        public virtual Task<bool> Delete(Guid id)
        {
            return repository.Delete(id);
        }
    }
}