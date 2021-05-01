using System;
using MetricsAgent.Validators;

namespace MetricsAgent.Dtos
{
    public class DateTimeRangeDto
    {
        [DateTimeRangeValidate]
        public DateTimeOffset From { get; set; } = DateTimeOffset.UnixEpoch;
        public DateTimeOffset To { get; set; } = DateTimeOffset.MaxValue;
    }
}
