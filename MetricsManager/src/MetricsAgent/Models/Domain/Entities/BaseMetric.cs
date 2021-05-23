using System;

namespace MetricsAgent.Models.Domain.Entities
{
    public abstract class BaseMetric
    {
        public DateTimeOffset DateTime { get; init; }
    }
}
