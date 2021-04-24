using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetricsManager.Controllers.WeatherController
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherHistory _weatherHistory;
        public WeatherController(WeatherHistory weatherHistory)
        {
            _weatherHistory = weatherHistory;
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] Request.WeatherRequest weatherRequest)
        {
            return Ok(_weatherHistory.GetForDaysRange(weatherRequest.From, weatherRequest.To));
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] Weather weather)
        {
            return _weatherHistory.WeatherSet.Add(weather) ? Ok(weather) : Conflict();
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] Weather weather)
        {
            if (_weatherHistory.WeatherSet.TryGetValue(weather, out var actualValue))
            {
                actualValue.TemperatureC = weather.TemperatureC;
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] Weather weather)
        {
            return _weatherHistory.WeatherSet.Remove(weather) ? Ok(weather) : NotFound();
        }
    }
}
