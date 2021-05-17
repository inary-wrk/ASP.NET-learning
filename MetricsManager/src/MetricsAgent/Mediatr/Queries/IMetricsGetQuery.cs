using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Controllers.Dto;

namespace MetricsAgent.Mediatr.Queries
{
    public interface IMetricsGetQuery
    {
        public DateTimeRangeRequestDto DateTimeRange { get; }
    }
}
