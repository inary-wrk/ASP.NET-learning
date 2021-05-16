using MetricsAgent.Models.Domain.Entities;

namespace MetricsAgent.Models.Domain.Services
{
    public interface IMetricsCommandRepository<TMetric>
        where TMetric : BaseMetric
    {
        void CreateMetric(TMetric metric);
    }
}
