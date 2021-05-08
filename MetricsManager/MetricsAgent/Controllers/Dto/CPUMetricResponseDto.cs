using System;

namespace MetricsAgent.Controllers.Dto
{
    public class CPUMetricResponseDto : BaseMetricResponceDto
    {
        public int Something { get; }
        public CPUMetricResponseDto(DateTimeOffset dateTime, int something) : base(dateTime)
        {
            Something = something;
        }

    }
}