using implementation.Models.Enums;

namespace implementation.Utils.Helpers
{
    public static class RepositoryHelpers
    {
        public static bool CanChangeOrderStatus(OrderStatus orderStatus, OrderStatus newOrderStatus)
        {
            if(orderStatus == newOrderStatus)
                return true;

            if(orderStatus == OrderStatus.WaitingPayment && (newOrderStatus == OrderStatus.RejectedPayment || newOrderStatus == OrderStatus.ApprovedPayment))
                return true;

            if(orderStatus == OrderStatus.ApprovedPayment && (newOrderStatus == OrderStatus.RejectedPayment || newOrderStatus == OrderStatus.Sended))
                return true;

            if(orderStatus == OrderStatus.Sended && newOrderStatus == OrderStatus.Delivered)
                return true;

            return false;
        }
    }
}