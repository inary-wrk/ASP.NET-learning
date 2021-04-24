using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherLib
{
    public class Weather : IComparable<Weather>
    {
        
        [BindRequired]
        public DateTime Date { get; set; }
        [BindRequired]
        public int TemperatureC { get; set; }

        public int CompareTo(Weather other) => Date.CompareTo(other.Date);
    }
}
