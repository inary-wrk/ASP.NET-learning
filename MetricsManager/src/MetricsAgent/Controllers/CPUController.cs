using MediatR;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.Mediatr.Queries;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetCPUMetrics([FromQuery] DateTimeRangeRequestDto dateTimeRange)
        {
            var query = new CPUMetricsGetQuery(dateTimeRange);
            var result = _mediator.Send(query);
            return Ok(result.Result);
        }
    }
}
