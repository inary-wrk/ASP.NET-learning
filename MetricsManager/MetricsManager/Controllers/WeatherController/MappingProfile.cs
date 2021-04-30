using AutoMapper;
using MetricsManager.Models.Domain;
using System;

namespace MetricsManager.Controllers.WeatherController
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherDto, Weather>();
        }
    }
}
