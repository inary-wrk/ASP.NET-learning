using System;

namespace MetricsAgent.Models.Domain.Entities
{
    public class CPUMetric : BaseMetric
    {
        public int CpuUsage { get; init; }
    }
}
