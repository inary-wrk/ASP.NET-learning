using MetricsManager.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers.Metrics
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HardDriveController : ControllerBase
    {
        [HttpGet("left/agent")]
        public IActionResult GetMetricsFromAgent(
           [FromQuery] AgentIdRequestDto agentId,
           [FromQuery] DateTimeRangeDto dateTimeRange)
        {
            return Ok();
        }

        [HttpGet("left/cluster")]
        public IActionResult GetMetricsFromCluster([FromQuery] DateTimeRangeDto dateTimeRange)
        {
            return Ok();
        }
    }
}
