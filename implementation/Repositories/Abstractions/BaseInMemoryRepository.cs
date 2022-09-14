using implementation.Models.Abstractions;
using implementation.Repositories.Interfaces;

namespace implementation.Repositories.Abstractions
{
    public class BaseInMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private List<TEntity> _entities;

        public BaseInMemoryRepository()
        {
            _entities = new List<TEntity>();
        } 
        public virtual void Create(TEntity item)
        {
            var newId = 1;

            if(GetAll().Count() > 0)
                newId = _entities.Max(entity => entity.Id) + 1;

            item.Id = newId;

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

            if(entityToChange == null)
                return;

            Delete(id);
            Create(item);
        }
    }
}