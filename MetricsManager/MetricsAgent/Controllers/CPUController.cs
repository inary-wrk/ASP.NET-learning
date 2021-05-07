using MediatR;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.Mediatr.Queries;
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
        private readonly IMediator _mediator;

        public CPUController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetCPUMetrics([FromQuery] DateTimeRangeDto dateTimeRange)
        {
            var query = new GetCPUMetricsQuery(dateTimeRange);
            var result = _mediator.Send(query);
            return Ok(result);
        }
    }
}
