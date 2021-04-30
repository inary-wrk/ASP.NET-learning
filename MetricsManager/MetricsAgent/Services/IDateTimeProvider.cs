using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Services
{
    interface IDateTimeProvider
    {
        public DateTimeOffset DateTime { get; set; }
    }
}
