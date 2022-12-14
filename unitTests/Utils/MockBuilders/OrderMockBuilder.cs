using implementation.Controllers;
using implementation.Infrastructure.Config;
using implementation.Repositories;
using implementation.Services;
using unitTests.Utils.MockBuilders.Abstractions;
using static unitTests.Utils.Helpers.OrderHelpers;

namespace unitTests.Utils.MockBuilders
{
    public class OrderMockBuilder : BaseMockBuilder<OrderController>
    {
        public OrderController OrderController
        {
            get
            {
                if (_controller == null)
                    _controller = BuildController();

                return _controller;
            }
        }

        public OrderMockBuilder()
        {
            FillRepositoryData();
        }

        protected override OrderController BuildController()
        {
            var repository = new OrderInMemoryRepository();

            var service = new OrderService(repository, MappingConfig.RegisterMaps().CreateMapper());

            return new OrderController(service);
        }

        protected override void FillRepositoryData()
        {
            foreach (var order in GenerateOrders())
                OrderController.Create(order);
        }
    }
}