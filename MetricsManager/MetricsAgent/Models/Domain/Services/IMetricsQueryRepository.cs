using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Domain.Services
{
    public interface IMetricsQueryRepository<TMetric>
        where TMetric : class
    {
        IReadOnlyCollection<TMetric> GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to);
    }
}
