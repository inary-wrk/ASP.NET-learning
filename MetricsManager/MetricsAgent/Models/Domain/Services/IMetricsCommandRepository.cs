using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Domain.Services
{
    interface IMetricsCommandRepository<TMetric>
        where TMetric : class
    {
        public bool Create(TMetric metric);
    }
}
