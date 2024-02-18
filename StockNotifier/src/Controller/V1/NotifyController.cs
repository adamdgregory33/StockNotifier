﻿using Microsoft.AspNetCore.Mvc;
using StockNotifier.src.Model.Internal.Controller.V1;

namespace StockNotifier.src.Controller.V1
{
    [Route("/v1/api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        // POST v1/api/<NotifyController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public IActionResult Post([FromBody] NotifyModel request)
        {
            if (request is null)
                return BadRequest();

            return Accepted();
        }

    }
}
