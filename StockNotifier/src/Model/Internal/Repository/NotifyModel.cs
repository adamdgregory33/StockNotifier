using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace StockNotifier.src.Model.Internal.Respository
{
    public class NotifyModel
    {
        public string BrokerId { get; set; }
        public string Ticker { get; set; }
        public Decimal PriceTraded { get; set; }
        public Decimal NumberOfShares { get; set; }
    }
}
