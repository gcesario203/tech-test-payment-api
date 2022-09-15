using implementation.Data;
using implementation.Models;
using unitTests.Utils.MockBuilders;
using static implementation.Utils.Helpers.ControllerHelpers;
using static unitTests.Utils.Helpers.OrderHelpers;

namespace unitTests
{
    public class OrderUnitTests
    {
        [Fact]
        public void ShouldCreateTheFifthUserOfTheSystem()
        {
            var mockBuilder = new OrderMockBuilder();

            var result = mockBuilder.OrderController.Create(MockUser());

            Assert.Equal(HandleActionResult<Order>(result).Id, 5);
        }

        [Fact]
        public void ShouldTheNewUser()
        {
        }
    }
}