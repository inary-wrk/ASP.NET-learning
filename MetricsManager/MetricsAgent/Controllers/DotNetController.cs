using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Controllers.Dto;

namespace MetricsAgent.Controllers
{
    [Route("api/dotnet")]
    [ApiController]
    public class DotNetController : Controller
    {
        [HttpGet("errors-count")]
        public IActionResult Get([FromQuery] DateTimeRangeRequestDto dateTimeRange)
        {
            return Ok();
        }
    }
}
