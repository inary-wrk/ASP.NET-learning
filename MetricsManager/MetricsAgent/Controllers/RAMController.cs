using MetricsAgent.Controllers.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
