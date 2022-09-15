using implementation.Models;
using implementation.Models.Enums;
using implementation.Repositories.Abstractions;
using static implementation.Utils.Helpers.ReflectionHelpers;

namespace implementation.Repositories
{
    public class OrderInMemoryRepository : BaseInMemoryRepository<Order>
    {
        public override bool Create(Order item)
        {
            item.Status = Models.Enums.OrderStatus.WaitingPayment;

            return base.Create(item);
        }

        public override bool UpdateField<TField>(int id, TField value)
        {
            if(!(value is OrderStatus))
                return false;

            var formatedValue = GetValue<OrderStatus>(value);

            var itemToChange = GetById(id);

            if(itemToChange == null)
                return false;

            itemToChange.Status = formatedValue;

            return base.Update(id, itemToChange);
        }
    }
}