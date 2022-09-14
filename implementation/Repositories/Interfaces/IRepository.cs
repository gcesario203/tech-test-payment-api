using implementation.Models.Abstractions;

namespace implementation.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        bool Create(TEntity item);

        bool Update(int id, TEntity item);

        bool Delete(int id);
    }
}