using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Domain.Services
{
    public interface IGetMetricsRepository<T>
        where T : class
    {
        IReadOnlyCollection<T> GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to);
    }
}
