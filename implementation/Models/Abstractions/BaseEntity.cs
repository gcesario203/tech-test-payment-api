
namespace implementation.Models.Abstractions
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public BaseEntity(int id)
        {
            Id = id;
        }
    }
}