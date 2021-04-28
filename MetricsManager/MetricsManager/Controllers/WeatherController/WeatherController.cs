using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Models.Domain;
using MetricsManager.Controllers.WeatherController.Dto;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetricsManager.Controllers.WeatherController
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _weatherHistory;
        private readonly IMapper _mapper;

        public WeatherController(IWeatherRepository weatherHistory, IMapper mapper)
        {
            _weatherHistory = weatherHistory;
            _mapper = mapper;
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTimeDto weatherRequest)
        {
            return Ok(_weatherHistory.Get(weatherRequest.From, weatherRequest.To));
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] WeatherDto weather)
        {
            var modelWeather = _mapper.Map<Weather>(weather);
            return _weatherHistory.Create(modelWeather) ? Ok(weather) : Conflict();
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] WeatherDto weather)
        {
            var modelWeather = _mapper.Map<Weather>(weather);
            return _weatherHistory.Update(modelWeather) ? Ok() : NotFound();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] WeatherDto weather)
        {
            var modelWeather = _mapper.Map<Weather>(weather);
            return _weatherHistory.Delete(modelWeather) ? Ok(weather) : NotFound();
        }
    }
}
