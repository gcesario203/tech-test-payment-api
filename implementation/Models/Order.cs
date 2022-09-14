
using implementation.Models.Abstractions;
using implementation.Models.Enums;

namespace implementation.Models
{
    public class Order : BaseEntity
    {
        public Seller Seller { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public OrderStatus Status {get; set;}
    }
}