using Xunit;
using System;
using MetricsAgent.Controllers.Dto;
using FluentValidation.TestHelper;

namespace MetricsAgent.Validators.Tests
{
    public class DateTimeRangeRequestDtoValidatorTests
    {
        private readonly DateTimeRangeRequestDtoValidator _validator;

        public DateTimeRangeRequestDtoValidatorTests()
        {
            _validator = new DateTimeRangeRequestDtoValidator();
        }

       
        [Fact()]
        public void Should_have_error_when_DateTime_less_UnixTime()
        {
            var dateTimeRange = new DateTimeRangeRequestDto()
            {
                From = DateTimeOffset.Parse("1800-01-01"),
                To = DateTimeOffset.Parse("1800-12-01")
            };

           var result = _validator.TestValidate(dateTimeRange);
            result.ShouldHaveValidationErrorFor(x => x.From);
        }

        [Fact()]
        public void Should_have_error_when_To_less_From()
        {
            var dateTimeRange = new DateTimeRangeRequestDto()
            {
                From = DateTimeOffset.Parse("2000-01-01"),
                To = DateTimeOffset.Parse("1980-12-01")
            };

            var result = _validator.TestValidate(dateTimeRange);
            result.ShouldHaveValidationErrorFor(x => x.From);
        }


        [Fact()]
        public void Positive_test_conditions()
        {
            var dateTimeRange = new DateTimeRangeRequestDto()
            {
                From = DateTimeOffset.Parse("2000-01-01"),
                To = DateTimeOffset.Parse("2010-12-01")
            };

            var result = _validator.TestValidate(dateTimeRange);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}