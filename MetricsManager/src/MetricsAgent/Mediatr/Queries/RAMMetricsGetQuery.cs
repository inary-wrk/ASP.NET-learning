using System.Collections.Generic;
using MediatR;
using MetricsAgent.Controllers.Dto;

namespace MetricsAgent.Mediatr.Queries
{
    public class RAMMetricsGetQuery: IRequest<IReadOnlyCollection<RAMMetricResponseDto>>, IMetricsGetQuery
    {
        public DateTimeRangeRequestDto DateTimeRange { get; }

        public RAMMetricsGetQuery(DateTimeRangeRequestDto dateTimeRange)
        {
            DateTimeRange = dateTimeRange;
        }
    }
}