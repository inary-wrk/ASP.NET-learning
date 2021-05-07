using MediatR;
using System.Collections.Generic;
using MetricsAgent.Controllers.Dto;

namespace MetricsAgent.Mediatr.Queries
{
    public class GetCPUMetricsQuery : IRequest<IReadOnlyCollection<CPUMetricsResponceDto>>
    {
        public DateTimeRangeDto DateTimeRange { get; }

        public GetCPUMetricsQuery(DateTimeRangeDto dateTimeRange)
        {
            DateTimeRange = dateTimeRange;
        }
    }
}