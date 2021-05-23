using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers.Dto
{
    public abstract class BaseMetricResponseDto

    {
        public DateTimeOffset DateTime { get; set; }
    }
}
