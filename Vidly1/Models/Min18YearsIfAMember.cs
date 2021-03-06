using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MenbershipTypeId == MembershipType.Unknown || 
                customer.MenbershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthday == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            var age = DateTime.Today.Year - (int)customer.Birthday.Year;

            return (age > 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on membership.");
        }
    }
}