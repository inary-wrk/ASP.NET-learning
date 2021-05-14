using Microsoft.AspNetCore.Mvc;
using MetricsAgent.Controllers.Dto;
using MediatR;
using MetricsAgent.Mediatr.Queries;

namespace MetricsAgent.Controllers
{
    [Route("api/dotnet")]
    [ApiController]
    public class DotNetController : Controller
    {
        private readonly IMediator _mediator;

        public DotNetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("errors-count")]
        public IActionResult Get([FromQuery] DateTimeRangeRequestDto dateTimeRange)
        {
            var query = new DotNetMetricsGetQuery(dateTimeRange);
            var result = _mediator.Send(query);
            return Ok(result.Result);
        }
    }
}
