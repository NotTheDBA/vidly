using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class NotFutureBirthDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            var future = customer.BirthDate.Value.Date.Subtract(DateTime.Today.Date).Days;

            return (future > 0)
                ? new ValidationResult("Future dates are not allowed.")
                : ValidationResult.Success;
        }
    }
}