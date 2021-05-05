using MetricsManager.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers.Metrics
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetController : Controller
    {
        [HttpGet("errors-count/agent")]
        public IActionResult GetMetricsFromAgent(
            [FromQuery] AgentIdRequestDto agentId,
            [FromQuery] DateTimeRangeDto dateTimeRange)
        {
            return Ok();
        }

        [HttpGet("errors-count/cluster")]
        public IActionResult GetMetricsFromCluster([FromQuery] DateTimeRangeDto dateTimeRange)
        {
            return Ok();
        }
    }
}
