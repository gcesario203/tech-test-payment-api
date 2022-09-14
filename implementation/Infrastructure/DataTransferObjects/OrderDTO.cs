using implementation.Models;
using implementation.Models.Enums;

namespace implementation.DataTransferObjects
{
    public class OrderDTO
    {
        public Seller Seller { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public OrderStatus Status { get; set; }
    }
}