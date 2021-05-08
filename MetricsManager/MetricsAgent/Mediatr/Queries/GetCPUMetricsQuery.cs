using MediatR;
using System.Collections.Generic;
using MetricsAgent.Controllers.Dto;

namespace MetricsAgent.Mediatr.Queries
{
    public class GetCPUMetricsQuery : IRequest<IReadOnlyCollection<CPUMetricResponseDto>>
    {
        public DateTimeRangeRequestDto DateTimeRange { get; }

        public GetCPUMetricsQuery(DateTimeRangeRequestDto dateTimeRange)
        {
            DateTimeRange = dateTimeRange;
        }
    }
}