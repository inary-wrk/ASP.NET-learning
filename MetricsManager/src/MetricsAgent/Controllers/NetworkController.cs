using MediatR;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.Mediatr.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/network")]
    [ApiController]
    public class NetworkController : Controller
    {
        private readonly IMediator _mediator;

        public NetworkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] DateTimeRangeRequestDto dateTimeRange)
        {
            var query = new NetworkMetricsGetQuery(dateTimeRange);
            var result = _mediator.Send(query);
            return Ok(result.Result);
        }
    }
}
