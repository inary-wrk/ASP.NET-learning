using MetricsAgent.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/cpu")]
    [ApiController]
    public class CPUController : Controller
    {
        [HttpGet]
        public IActionResult Get([FromQuery] DateTimeRangeDto dateTimeRange)
        {
            return Ok();
        }
    }
}
