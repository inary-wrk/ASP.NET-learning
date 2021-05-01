using System;
using System.ComponentModel.DataAnnotations;


namespace MetricsAgent.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateTimeRangeValidate : ValidationAttribute
    {
        public DateTimeOffset From { get; set; } = DateTimeOffset.UnixEpoch;
        public DateTimeOffset To { get; set; } = DateTimeOffset.MaxValue;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTimeOffset actualValue)
            {
                if ((actualValue >= From) && (actualValue <= To))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("DateTime is out of range.");
        }

    }
}
