using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MetricsManager.Controllers.WeatherController.Dto
{
    public class WeatherDto
    {
        [BindRequired]
        public DateTime Date { get; set; }
        [BindRequired]
        public int TemperatureC { get; set; }
    }
}
