using MetricsAgent.Controllers.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{

    [Route("api/ram")]
    [ApiController]
    public class RAMController : Controller
    {
        [HttpGet("available-space")]
        public IActionResult Get([FromQuery] DateTimeRangeRequestDto dateTimeRange)
        {
            return Ok();
        }
    }
}
