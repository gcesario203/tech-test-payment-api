using implementation.Models;
using implementation.Models.Enums;
using unitTests.Utils.MockBuilders;
using static implementation.Utils.Helpers.ControllerHelpers;
using static unitTests.Utils.Helpers.OrderHelpers;

namespace unitTests
{
    public class OrderUnitTests
    {

        [Fact]
        public void ShoudlGetTheFourthOrder()
        {
            var mockBuilder = new OrderMockBuilder();

            var result = mockBuilder.OrderController.GetById(4);

            Assert.NotEqual(HandleActionResult<Order>(result), null);
        }

        [Fact]
        public void ShouldNotFindThirtyFifthOrder()
        {
            var mockBuilder = new OrderMockBuilder();

            var result = mockBuilder.OrderController.GetById(35);

            Assert.Equal(HandleActionResult<Order>(result), null);
        }

        [Fact]
        public void ShouldCreateTheFifthUserOfTheSystem()
        {
            var mockBuilder = new OrderMockBuilder();

            var result = mockBuilder.OrderController.Create(MockOrder());

            Assert.Equal(HandleActionResult<Order>(result).Id, 5);
        }

        [Fact]
        public void ShouldntCreateOrderWithoutProducts()
        {
            var mockBuilder = new OrderMockBuilder();

            var mockOrder = MockOrder();

            mockOrder.Products = null;

            var result = mockBuilder.OrderController.Create(mockOrder);

            Assert.Equal(HandleActionResult<Order>(result), null);
        }

        [Fact]
        public void ANewUserHasToHaveDefaultDateTimeAtFieldUpdatedAt()
        {
            var mockBuilder = new OrderMockBuilder();

            var mockOrder = MockOrder();

            mockOrder.Products = null;

            var result = mockBuilder.OrderController.Create(mockOrder);

            Assert.Equal(HandleActionResult<Order>(result), null);
        }

        [Fact]
        public void ShouldTheNewUserStartWithPendingPaymentStatus()
        {
            var mockBuilder = new OrderMockBuilder();
            var mockOrder = MockOrder();

            mockOrder.Status = OrderStatus.ApprovedPayment;

            var result = mockBuilder.OrderController.Create(mockOrder);

            Assert.Equal(HandleActionResult<Order>(result).Status, OrderStatus.WaitingPayment);
        }
    }
}