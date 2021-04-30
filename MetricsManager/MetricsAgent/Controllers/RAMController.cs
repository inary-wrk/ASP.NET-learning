using MetricsAgent.Services;
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
        public IActionResult Get([FromQuery] IDateTimeProvider from, [FromQuery] IDateTimeProvider to)
        {
            return Ok();
        }
    }
}
