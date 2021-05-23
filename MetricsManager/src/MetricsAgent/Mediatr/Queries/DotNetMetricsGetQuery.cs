using MediatR;
using System.Collections.Generic;
using MetricsAgent.Controllers.Dto;

namespace MetricsAgent.Mediatr.Queries
{
    public class DotNetMetricsGetQuery : IRequest<IReadOnlyCollection<DotNetMetricResponseDto>>, IMetricsGetQuery
    {
        public DateTimeRangeRequestDto DateTimeRange { get; }

        public DotNetMetricsGetQuery(DateTimeRangeRequestDto dateTimeRange)
        {
            DateTimeRange = dateTimeRange;
        }
    }
}