using System.Collections.Generic;
using MediatR;
using MetricsAgent.Controllers.Dto;

namespace MetricsAgent.Mediatr.Queries
{
    public class HardDriveMetricsGetQuery : IRequest<IReadOnlyCollection<HardDriveMetricResponseDto>>
    {
        public DateTimeRangeRequestDto DateTimeRange { get; } 

        public HardDriveMetricsGetQuery(DateTimeRangeRequestDto dateTimeRange)
        {
            DateTimeRange = dateTimeRange;
        }
    }
}