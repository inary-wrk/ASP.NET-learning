using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib
{
    public class WeatherHistory
    {
        public SortedSet<Weather> WeatherSet { get; set; }

        public WeatherHistory()
        {
            WeatherSet = new();
        }

        public IEnumerable<Weather> GetForDaysRange(DateTime from, DateTime to) 
            => WeatherSet.TakeWhile(x => x.Date >= from && x.Date <= to);
    }
}
