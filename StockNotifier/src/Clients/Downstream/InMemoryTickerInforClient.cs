using StockNotifier.src.Model.Internal.Clients;

namespace StockNotifier.src.Clients.Downstream
{
    public class InMemoryTickerInforClient : ITickerInfoClient
    {
        private static List<TickerInfoModel> TICKERS => new List<TickerInfoModel>()
        {
            CreateTickerInfo("AAPL",new Decimal(100)),
            CreateTickerInfo("ABT",new Decimal(53)),
            CreateTickerInfo("MSFT",new Decimal(12)),
            CreateTickerInfo("BANANA",new Decimal(1000)),
        };

        public List<TickerInfoModel> GetAllTickerInfos()
        {
            return TICKERS;
        }

        public TickerInfoModel GetTickerInfo(string ticker)
        {
            // Assuming tickers are unique in collection, would be in practice
            return TICKERS
                .Where(x => x.Ticker.Equals(ticker, StringComparison.OrdinalIgnoreCase))
                .First();
        }

        public List<TickerInfoModel> GetTickerInfos(List<string> tickers)
        {
            return TICKERS
                .Where(x => tickers.Contains(x.Ticker))
                .ToList();
        }

        private static TickerInfoModel CreateTickerInfo(string name, decimal value)
        => new TickerInfoModel
            {
                Ticker = name,
                Price = value
            };
        
    }
}
