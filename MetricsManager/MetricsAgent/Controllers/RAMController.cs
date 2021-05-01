using MetricsAgent.Dtos;
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
        [HttpGet]
        public IActionResult Get([FromQuery] DateTimeRangeDto dateTimeRange)
        {
            return Ok();
        }
    }
}
