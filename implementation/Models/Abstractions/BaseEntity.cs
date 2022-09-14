
namespace implementation.Models.Abstractions
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; set; }

        public BaseEntity(int id)
        {
            Id = id;

            CreatedAt = DateTime.Now;
        }
    }
}