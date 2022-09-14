
using implementation.Models.Abstractions;

namespace implementation.Models
{
    public class Order : BaseEntity
    {
        public int SellerId { get; private set; }

        public List<int> ProductIds { get; private set; }

        public Order(int id, int sellerId, List<int> products) : base(id)
        {
            SellerId = sellerId;
            ProductIds = products;
        }
    }
}