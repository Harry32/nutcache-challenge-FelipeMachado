namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(Guid id);

        Task<bool> Insert(TEntity entity);

        Task<bool> Update(TEntity entity);

        Task<bool> Delete(Guid id);
    }
}