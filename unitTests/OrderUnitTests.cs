using implementation.Data;
using implementation.Models;
using unitTests.Utils.MockBuilders;
using static implementation.Utils.Helpers.ControllerHelpers;

namespace unitTests
{
    public class OrderUnitTests
    {
        [Fact]
        public void ShouldCreateAValidOrder()
        {
            var mockBuilder = new OrderMockBuilder();

            var newOrder = new OrderDTO
            {
                Seller = new Seller
                {
                    Name = "Evelyn Vera Ester Assunção",
                    Cpf = "71444185055",
                    Email = "evelyn.vera.assuncao@hidrara.com.br",
                    Telphone = "8335501389"
                }
            };

            var result = mockBuilder.OrderController.Create(newOrder);

            Assert.Equal(HandleActionResult<Order>(result).Id, 5);
        }
    }
}