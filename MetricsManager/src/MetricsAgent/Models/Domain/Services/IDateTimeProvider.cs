using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Domain.Services
{
    public interface IDateTimeProvider
    {
        public DateTimeOffset UtcNow { get; }
    }
}
