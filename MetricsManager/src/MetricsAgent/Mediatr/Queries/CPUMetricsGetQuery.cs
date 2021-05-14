using MediatR;
using System.Collections.Generic;
using MetricsAgent.Controllers.Dto;

namespace MetricsAgent.Mediatr.Queries
{
    public class CPUMetricsGetQuery : IRequest<IReadOnlyCollection<CPUMetricResponseDto>>
    {
        public DateTimeRangeRequestDto DateTimeRange { get; }

        public CPUMetricsGetQuery(DateTimeRangeRequestDto dateTimeRange)
        {
            DateTimeRange = dateTimeRange;
        }
    }
}