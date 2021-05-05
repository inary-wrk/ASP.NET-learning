using MetricsManager.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/agents")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromQuery] AgentInfoRequestDto agentInfo)
        {
            return Ok();
        }

        [HttpGet("agentsList")]
        public IActionResult GetAgentsList()
        {
            return Ok();
        }

        [HttpPut("disable")]
        public IActionResult DisableAgent([FromQuery] AgentIdRequestDto agentID)
        {
            return Ok();
        }

        [HttpPut("enable")]
        public IActionResult EnableAgent([FromQuery] AgentIdRequestDto agentID)
        {
            return Ok();
        }
    }
}
