using Microsoft.AspNetCore.Mvc;

namespace StockNotifier.src.Controller
{
    [Route("/v1/api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        // POST api/<NotifyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine(value);
        }

    }
}
