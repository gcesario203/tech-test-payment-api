using implementation.Models.Abstractions;

namespace implementation.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Create(TEntity item);

        void Update(int id, TEntity item);

        void Delete(int id);
    }
}