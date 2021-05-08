using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.DAL.Models;

namespace MetricsAgent.Mapping
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<DateTimeRangeRequestDto, TestClassDate>()
            //    .GenerateMapper(MapType.Map | MapType.MapToTarget);
        }
    }
}
