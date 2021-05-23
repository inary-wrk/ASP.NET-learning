using System.Collections.Generic;
using MediatR;
using MetricsAgent.Controllers.Dto;

namespace MetricsAgent.Mediatr.Queries
{
    public class NetworkMetricsGetQuery : IRequest<IReadOnlyCollection<NetworkMetricResponseDto>>, IMetricsGetQuery
    {
        public DateTimeRangeRequestDto DateTimeRange { get; }

        public NetworkMetricsGetQuery(DateTimeRangeRequestDto dateTimeRange)
        {
            DateTimeRange = dateTimeRange;
        }
    }
}