using implementation.Models;
using implementation.Repositories.Abstractions;

namespace implementation.Repositories
{
    public class OrderInMemoryRepository : BaseInMemoryRepository<Order>
    {
        public override bool Create(Order item)
        {
            item.Status = Models.Enums.OrderStatus.WaitingPayment;

            return base.Create(item);
        }
    }
}