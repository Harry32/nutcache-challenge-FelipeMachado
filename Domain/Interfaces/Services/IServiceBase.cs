namespace Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> Get(Guid id);

        Task<bool> Insert(TEntity entity);

        Task<bool> Update(TEntity entity);

        Task<bool> Delete(Guid id);
    }
}