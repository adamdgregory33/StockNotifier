using Microsoft.AspNetCore.Mvc;
using StockNotifier.src.Clients.Downstream;
using StockNotifier.src.Model.Internal.Controller.V1;

namespace StockNotifier.src.Controller.V1
{
    [Route("/v1/api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly INotifyRepository _notifyRepository;
        private readonly ITickerInfoClient _tickerInfoClient;

        public NotifyController(
            INotifyRepository notifyRepository,
            ITickerInfoClient tickerInfoClient)
        {
            _notifyRepository = notifyRepository;
            _tickerInfoClient = tickerInfoClient;
        }

        // POST v1/api/<NotifyController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Post([FromBody] NotifyDto request)
        {
            if (request is null)
                return BadRequest();

            await _notifyRepository
                .AddTradeNotification(
                    request.BrokerId,
                    request.Ticker,
                    request.NumberOfShares,
                    request.PriceTraded
                    );

            var tickerInfo = _tickerInfoClient.GetTickerInfo( request.BrokerId );

            return Accepted(tickerInfo);
        }

    }
}
