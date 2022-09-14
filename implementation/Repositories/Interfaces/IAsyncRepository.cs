using implementation.Models.Abstractions;

namespace implementation.Repositories.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity item);

        Task Update(int id, TEntity item);

        Task Delete(int id);
    }
}