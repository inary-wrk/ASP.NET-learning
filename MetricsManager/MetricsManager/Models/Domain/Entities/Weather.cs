using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;


namespace MetricsManager.Models.Domain
{
    public class Weather : IComparable<Weather>
    {
        
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }

        public int CompareTo(Weather other) => Date.CompareTo(other.Date);
    }
}
