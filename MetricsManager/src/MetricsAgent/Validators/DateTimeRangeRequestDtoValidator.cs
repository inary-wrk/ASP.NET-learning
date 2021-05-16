using System;
using FluentValidation;
using MetricsAgent.Controllers.Dto;

namespace MetricsAgent.Validators
{
    public class DateTimeRangeRequestDtoValidator : AbstractValidator<DateTimeRangeRequestDto>
    {
        public DateTimeRangeRequestDtoValidator()
        {
            RuleFor(x => x.From).GreaterThanOrEqualTo(DateTimeOffset.UnixEpoch);
            RuleFor(x=>x.To).GreaterThanOrEqualTo(DateTimeOffset.UnixEpoch);
        }
    }
}
