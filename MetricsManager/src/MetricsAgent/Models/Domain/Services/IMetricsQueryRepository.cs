using MetricsAgent.Models.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MetricsAgent.Models.Domain.Services
{
    public interface IMetricsQueryRepository<TMetric>
       where TMetric : BaseMetric
    {
        IReadOnlyCollection<TMetric> GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to);
    }
}
