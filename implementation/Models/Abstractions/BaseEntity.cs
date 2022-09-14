
using System.Diagnostics.CodeAnalysis;

namespace implementation.Models.Abstractions
{
    public abstract class BaseEntity : IEqualityComparer<BaseEntity>
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Equals(BaseEntity? x, BaseEntity? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] BaseEntity obj)
        {
            return Id.GetHashCode();
        }
    }
}