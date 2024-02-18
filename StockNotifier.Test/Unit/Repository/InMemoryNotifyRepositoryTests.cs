using AutoFixture;
using StockNotifier.src.Model.Internal.Respository;
using StockNotifier.src.Repository;


namespace StockNotifier.Test.Unit.Repository
{
    public class InMemoryNotifyRepositoryTests
    {

        private readonly InMemoryNotifyRepository _repository;
        private readonly IFixture _fixture;

        public InMemoryNotifyRepositoryTests()
        {
            _repository = new InMemoryNotifyRepository();
            _fixture = new Fixture();
        }

        [Fact]
        public async Task AddTrade_ValidInputs_ReturnsModel()
        {
            var notifyModel = _fixture.Create<NotifyModel>();
            var result = await _repository.AddTradeNotification(notifyModel.BrokerId, notifyModel.Ticker, notifyModel.NumberOfShares, notifyModel.PriceTraded);

            Assert.NotNull(result);
            Assert.Equal(notifyModel.PriceTraded, result.PriceTraded);
            Assert.Equal(notifyModel.NumberOfShares, result.NumberOfShares);
            Assert.Equal(notifyModel.Ticker, result.Ticker);
            Assert.Equal(notifyModel.BrokerId, result.BrokerId);

        }

        [Fact]
        public async Task AddTrade_InvalidInputs_ThrowsException()
        {
            var notifyModel = _fixture.Create<NotifyModel>();
            notifyModel.Ticker = null;
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _repository.AddTradeNotification(notifyModel.BrokerId, notifyModel.Ticker, notifyModel.NumberOfShares, notifyModel.PriceTraded));
        }
    }
}
