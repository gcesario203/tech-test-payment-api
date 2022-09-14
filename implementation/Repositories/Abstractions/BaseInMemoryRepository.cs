using implementation.Models.Abstractions;
using implementation.Repositories.Interfaces;
using static implementation.Utils.Helpers.DataBaseHelpers;

namespace implementation.Repositories.Abstractions
{
    public abstract class BaseInMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private List<TEntity> _entities;

        public BaseInMemoryRepository()
        {
            _entities = new List<TEntity>();
        }
        public virtual bool Create(TEntity item)
        {
            item.Id = GetInMemoryCollectionNewId(_entities.Count > 0 ? _entities.Max(entity => entity.Id) : 1);
            item.CreatedAt = DateTime.Now;

            _entities.Add(item);

            return true;
        }

        public virtual bool Delete(int id)
        {
            var itemToRemove = GetById(id);

            if(itemToRemove == null)
                return false;
            
            _entities.RemoveAll(entity => entity.Id == id);

            return true;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual TEntity GetById(int id)
        {
            return _entities.FirstOrDefault(entity => entity.Id == id);
        }

        public virtual bool Update(int id, TEntity item)
        {
            var entityToChange = GetById(id);

            if (entityToChange == null)
                return false;

            item.UpdatedAt = DateTime.Now;
            item.CreatedAt = entityToChange.CreatedAt;
            item.Id = entityToChange.Id;

            Delete(id);

            _entities.Add(item);

            return true;
        }
    }
}