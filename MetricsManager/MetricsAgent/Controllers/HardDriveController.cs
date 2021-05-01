using MetricsAgent.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/hdd")]
    [ApiController]
    public class HardDriveController : Controller
    {
        [HttpGet("left")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
