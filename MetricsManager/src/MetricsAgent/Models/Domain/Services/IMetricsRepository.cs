using MetricsAgent.Models.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MetricsAgent.Models.Domain.Services
{
    public interface IMetricsRepository<TMetric>
       where TMetric : BaseMetric
    {
        void Create(TMetric metric);
        IReadOnlyCollection<TMetric> GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to);
    }
}
