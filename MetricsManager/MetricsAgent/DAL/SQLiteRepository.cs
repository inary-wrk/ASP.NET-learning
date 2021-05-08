using MetricsAgent.Models.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public class SQLiteRepository<TMetric> : IGetMetricsRepository<TMetric>, ICreateMetricRepository<TMetric>
        where TMetric : class
    {


        bool ICreateMetricRepository<TMetric>.Create(TMetric metric)
        {
            throw new NotImplementedException();
        }

        IReadOnlyCollection<TMetric> IGetMetricsRepository<TMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {
            throw new NotImplementedException();
        }
    }
}
