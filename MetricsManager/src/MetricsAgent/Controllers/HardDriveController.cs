using MediatR;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.Mediatr.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/hdd")]
    [ApiController]
    public class HardDriveController : Controller
    {
        private readonly IMediator _mediator;

        public HardDriveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("available-space")]
        public IActionResult Get([FromQuery] DateTimeRangeRequestDto dateTimeRange)
        {
            var query = new HardDriveMetricsGetQuery(dateTimeRange);
            var result = _mediator.Send(query);
            return Ok(result.Result);
        }
    }
}
