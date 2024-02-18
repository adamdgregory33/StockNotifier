using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace StockNotifier.src.Model.Internal.Controller.V1
{
    [DataContract]
    public class NotifyDto
    {
        [DataMember, Required]
        public string BrokerId { get; set; }

        [DataMember, Required]
        public string Ticker { get; set; }

        [DataMember, Required]
        public Decimal PriceTraded { get; set; }

        [DataMember, Required]
        public Decimal NumberOfShares { get; set; }

    }
}
