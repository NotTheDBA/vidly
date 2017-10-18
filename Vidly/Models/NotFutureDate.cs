using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class NotFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            var future = movie.ReleaseDate.Date.Subtract(DateTime.Today.Date).Days;

            return (future > 0)
                ? new ValidationResult("Future dates are not allowed.")
                : ValidationResult.Success;
        }
    }
}