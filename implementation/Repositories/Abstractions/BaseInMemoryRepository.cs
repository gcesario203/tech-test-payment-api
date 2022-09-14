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
        public virtual async Task Create(TEntity item)
        {
            _entities.Add(item);
        }

        public virtual async Task Delete(int id)
        {
            _entities.RemoveAll(entity => entity.Id == id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return _entities;
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return _entities.FirstOrDefault(entity => entity.Id == id);
        }

        public virtual async Task Update(int id, TEntity item)
        {
            var entityToChange = await GetById(id);

            if(entityToChange == null)
                return;

            await Delete(id);
            await Create(item);
        }
    }
}