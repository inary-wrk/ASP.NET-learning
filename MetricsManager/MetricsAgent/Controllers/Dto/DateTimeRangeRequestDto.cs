using System;

namespace MetricsAgent.Controllers.Dto
{
    public class DateTimeRangeRequestDto
    {
        public DateTimeOffset From { get; set; } = DateTimeOffset.UnixEpoch;
        public DateTimeOffset To { get; set; } = DateTimeOffset.MaxValue;
    }
}
