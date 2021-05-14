using MediatR;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.Mediatr.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{

    [Route("api/ram")]
    [ApiController]
    public class RAMController : Controller
    {
        private readonly IMediator _mediator;

        public RAMController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("available-space")]
        public IActionResult Get([FromQuery] DateTimeRangeRequestDto dateTimeRange)
        {
            var query = new RAMMetricsGetQuery(dateTimeRange);
            var result = _mediator.Send(query);
            return Ok(result.Result);
        }
    }
}
