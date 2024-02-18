using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace StockNotifier.src.Model.Internal.Controller.V1
{
    public class NotifyDto
    {
        [DataMember, Required]
        public string BrokerId { get; }

        [DataMember, Required]
        public string Ticker { get; }

        [DataMember, Required]
        public Decimal PriceTraded { get; }

        [DataMember, Required]
        public Decimal NumberOfShares { get; }

    }
}
