using AutoFixture;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StockNotifier.src.Controller.V1;
using StockNotifier.src.Model.Internal.Controller.V1;

namespace StockNotifier.Test.Unit.Controller
{
    public class NotifyControllerTests
    {
        private readonly NotifyController _controller;
        private readonly IFixture _fixture;

        public NotifyControllerTests()
        {
            _controller = new NotifyController();
            _fixture = new Fixture();
        }

        [Fact]
        public void Post_ValidData_ReturnsAccepted ()
        {
            var request = _fixture.Create<NotifyModel>();

            var result = _controller.Post(request);

            Assert.NotNull(result);
            Assert.True(result is AcceptedResult);
        }

        [Fact]
        public void Post_InvalidData_ReturnsBadRequest()
        {
            NotifyModel request = null;

            var result = _controller.Post(request);

            Assert.NotNull(result);
            Assert.True(result is BadRequestResult);
        }
    }
}