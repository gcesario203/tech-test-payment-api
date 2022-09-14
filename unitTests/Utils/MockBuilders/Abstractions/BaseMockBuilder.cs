using Microsoft.AspNetCore.Mvc;

namespace unitTests.Utils.MockBuilders.Abstractions
{
    public abstract class BaseMockBuilder<TController> where TController : ControllerBase
    {
        protected TController _controller;
        protected abstract TController BuildController();
        protected abstract void FillRepositoryData();
    }
}