using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Models.Domain
{
    public interface IWeatherRepository
    {
        bool Create(Weather weather);
        bool Update(Weather weather);
        bool Delete(Weather weather);
        ICollection<Weather> Get(DateTime from, DateTime to);
    }
}
