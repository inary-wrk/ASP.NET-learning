using MetricsAgent.Controllers.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MetricsAgent.Controllers
{
    [Route("api/network")]
    [ApiController]
    public class NetworkController : Controller
    {
        [HttpGet]
        public IActionResult Get([FromQuery] DateTimeRangeRequestDto dateTimeRange)
        {
            return Ok();
        }
    }
}
