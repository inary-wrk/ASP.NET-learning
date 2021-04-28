using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.Models.Domain;

namespace MetricsManager.Models.Application
{
    public class WeatherHistory : IWeatherRepository
    {
        private readonly SortedSet<Weather> _weatherSet;

        public WeatherHistory()
        {
            _weatherSet = new();
        }

        bool IWeatherRepository.Create(Weather weather)
        {
            return _weatherSet.Add(weather);
        }

        bool IWeatherRepository.Delete(Weather weather)
        {
            return _weatherSet.Remove(weather);
        }

        ICollection<Weather> IWeatherRepository.Get(DateTime from, DateTime to)
        {
            return _weatherSet.TakeWhile(x => x.Date >= from && x.Date <= to).ToArray();
        }

        bool IWeatherRepository.Update(Weather weather)
        {
            if (_weatherSet.TryGetValue(weather, out var actualValue))
            {
                actualValue.TemperatureC = weather.TemperatureC;
                return true;
            }
            return false;
        }

    }
}
