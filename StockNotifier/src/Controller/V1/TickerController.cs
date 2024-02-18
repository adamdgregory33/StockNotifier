using Microsoft.AspNetCore.Mvc;
using StockNotifier.src.Clients.Downstream;

namespace StockNotifier.src.Controller.V1
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TickerController : ControllerBase
    {
        private readonly ITickerInfoClient _tickerInfoClient;
        public TickerController(ITickerInfoClient tickerInfoClient)
        {
            _tickerInfoClient = tickerInfoClient;
        }

        // GET v1/api/<TickerController>
        [HttpGet, Route("id")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle([FromBody] string ticker)
        {
            if (string.IsNullOrWhiteSpace(ticker))
                return BadRequest();

            var tickerInfo = _tickerInfoClient.GetTickerInfo(ticker);

            return Ok(tickerInfo);
        }

        // GET v1/api/<TickerController>
        [HttpGet, Route("query")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList([FromQuery] List<string> tickers)
        {
            if (tickers is null || tickers.Count == 0)
                return BadRequest();

            var tickerInfo = _tickerInfoClient.GetTickerInfos(tickers);

            return Ok(tickerInfo);
        }

        // GET v1/api/<TickerController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var tickerInfo = _tickerInfoClient.GetAllTickerInfos();
            return Ok(tickerInfo);
        }
    }
}
