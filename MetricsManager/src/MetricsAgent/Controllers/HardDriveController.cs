using MetricsAgent.Controllers.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/hdd")]
    [ApiController]
    public class HardDriveController : Controller
    {
        [HttpGet("available-space")]
        public IActionResult Get([FromQuery] DateTimeRangeRequestDto dateTimeRange)
        {
            return Ok();
        }
    }
}
