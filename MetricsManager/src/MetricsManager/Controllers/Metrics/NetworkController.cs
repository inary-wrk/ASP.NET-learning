using MetricsManager.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers.Metrics
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkController : ControllerBase
    {
        [HttpGet("agent")]
        public IActionResult GetMetricsFromAgent(
            [FromQuery] AgentIdRequestDto agentId,
            [FromQuery] DateTimeRangeDto dateTimeRange)
        {
            return Ok();
        }

        [HttpGet("cluster")]
        public IActionResult GetMetricsFromCluster([FromQuery] DateTimeRangeDto dateTimeRange)
        {
            return Ok();
        }
    }
}
