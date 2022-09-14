using implementation.Models.Abstractions;
using implementation.Repositories.Interfaces;
using static implementation.Utils.Helpers.DataBaseHelpers;

namespace implementation.Repositories.Abstractions
{
    public class BaseInMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected List<TEntity> _entities;

        public BaseInMemoryRepository()
        {
            _entities = new List<TEntity>();
        }
        public virtual void Create(TEntity item)
        {
            item.Id = GetInMemoryCollectionNewId(_entities.Count > 0 ? _entities.Max(entity => entity.Id) : 0);
            item.CreatedAt = DateTime.Now;

            _entities.Add(item);
        }

        public virtual void Delete(int id)
        {
            _entities.RemoveAll(entity => entity.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual TEntity GetById(int id)
        {
            return _entities.FirstOrDefault(entity => entity.Id == id);
        }

        public virtual void Update(int id, TEntity item)
        {
            var entityToChange = GetById(id);

            if (entityToChange == null)
                return;

            item.UpdatedAt = DateTime.Now;

            Delete(id);

            _entities.Add(item);
        }
    }
}