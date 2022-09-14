using implementation.Models;
using implementation.Repositories.Abstractions;
using static implementation.Utils.Helpers.RepositoryHelpers;

namespace implementation.Repositories
{
    public class OrderInMemoryRepository : BaseInMemoryRepository<Order>
    {
        public override bool Create(Order item)
        {
            if (item.Products.Count == 0)
                return false;

            item.Status = Models.Enums.OrderStatus.WaitingPayment;

            return base.Create(item);
        }

        public override bool Update(int id, Order item)
        {
            if (item.Products.Count == 0)
                return false;

            var orderToChange = GetById(id);

            if (!CanChangeOrderStatus(orderToChange.Status, item.Status))
                return false;

            return base.Update(id, item);
        }
    }
}