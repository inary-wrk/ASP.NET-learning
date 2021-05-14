using MetricsAgent.Controllers.Dto;
using Microsoft.AspNetCore.Mvc;

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
