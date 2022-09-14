using implementation.Models;
using implementation.Repositories.Abstractions;

namespace implementation.Repositories
{
    public class OrderInMemoryRepository : BaseInMemoryRepository<Order>
    {
        public override void Create(Order item)
        {
            if (item.Products.Count == 0)
                return;

            item.Status = Models.Enums.OrderStatus.WaitingPayment;
            
            base.Create(item);
        }

        public override void Update(int id, Order item)
        {
            if(item.Products.Count == 0)
                return;
            

            base.Update(id, item);
        }
    }
}