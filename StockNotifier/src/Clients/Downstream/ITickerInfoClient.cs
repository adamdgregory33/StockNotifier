using StockNotifier.src.Model.Internal.Clients;

namespace StockNotifier.src.Clients.Downstream
{
    public interface ITickerInfoClient
    {
        public TickerInfoModel GetTickerInfo(string ticker);

        public List<TickerInfoModel> GetAllTickerInfos();

        public List<TickerInfoModel> GetTickerInfos(List<string> tickers);

    }
}
