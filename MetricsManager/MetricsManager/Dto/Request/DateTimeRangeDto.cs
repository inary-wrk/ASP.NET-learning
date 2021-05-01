using System;

namespace MetricsManager.Dto
{
    public class DateTimeRangeDto
    {
        public DateTimeOffset From { get; set; } = DateTimeOffset.UnixEpoch;
        public DateTimeOffset To { get; set; } = DateTimeOffset.MaxValue;
    }
}
