using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice1.Models
{
    public class DobCustomValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dob = Convert.ToDateTime(value);
                DateTime today = DateTime.Today;
                if (dob.Year > today.Year)
                {
                    return new ValidationResult("Enter a valid Year");
                }
                else if (dob.Year == today.Year && dob.Month > today.Month)
                {
                    return new ValidationResult("Enter a valid month");
                }
                else if (dob.Year == today.Year && dob.Month == today.Month && dob.Day > today.Day)
                {
                    return new ValidationResult("Enter a valid day");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }


            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }
    }
}