
using StockNotifier.src.Model.Internal.Respository;

namespace StockNotifier.src.Repository
{
    public class InMemoryNotifyRepository : INotifyRepository
    {
        // Use NoSQL Document style storage, Primary key Broker ID, Sort key Ticker
        // E.g DynamoDb / CosmosDB
        private static List<NotifyModel> TRADES;

        public InMemoryNotifyRepository() 
        {
            TRADES = new List<NotifyModel>();
        }


        public async Task<NotifyModel> AddTradeNotification(string brokerId, string ticker, decimal numberOfShares, decimal priceTraded)
        {
            ArgumentNullException.ThrowIfNull(brokerId);
            ArgumentNullException.ThrowIfNull(ticker);
            ArgumentNullException.ThrowIfNull(numberOfShares);
            ArgumentNullException.ThrowIfNull(priceTraded);

            return await AddTradeInternal(brokerId, ticker, numberOfShares, priceTraded);
        }

        private async Task<NotifyModel> AddTradeInternal(string broker, string ticker, decimal numberOfShares, decimal shareValue)
        {
            var notifyModel = new NotifyModel()
            {
                BrokerId = broker,
                Ticker = ticker,
                NumberOfShares = numberOfShares,
                PriceTraded = shareValue
            };
            TRADES.Add(notifyModel);
            return notifyModel;
        }
    }
}
