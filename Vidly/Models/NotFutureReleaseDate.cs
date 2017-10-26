using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class NotFutureReleaseDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            var future = movie.ReleaseDate.Date.Subtract(DateTime.Today.Date).Days;

            var future2 = movie.DateAdded.Date.Subtract(DateTime.Today.Date).Days;

            return (future > 0 || future2 > 0)
                ? new ValidationResult("Future dates are not allowed.")
                : ValidationResult.Success;
        }
    }
}