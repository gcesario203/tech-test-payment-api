using implementation.Models.Abstractions;

namespace implementation.Repositories.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<bool> Create(TEntity item);

        Task<bool> Update(int id, TEntity item);

        Task<bool> Delete(int id);
    }
}