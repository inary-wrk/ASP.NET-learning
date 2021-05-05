using MetricsManager.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers.Metrics
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RAMController : Controller
    {
        [HttpGet("available/agent")]
        public IActionResult GetMetricsFromAgent(
            [FromQuery] AgentIdRequestDto agentId,
            [FromQuery] DateTimeRangeDto dateTimeRange)
        {
            return Ok();
        }

        [HttpGet("available/cluster")]
        public IActionResult GetMetricsFromCluster([FromQuery] DateTimeRangeDto dateTimeRange)
        {
            return Ok();
        }
    }
}
