using StockNotifier.src.Model.Internal.Respository;

namespace StockNotifier.src
{
    public interface INotifyRepository
    {
        // Async if we were connected to an actual data store
        public Task<NotifyModel> AddTradeNotification(string brokerId, string ticker, decimal numberOfShares, decimal priceTraded);
    }
}
