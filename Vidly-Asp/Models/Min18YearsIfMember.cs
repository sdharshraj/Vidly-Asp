using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly_Asp.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if(customer.DateOfBirth == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;
            return (age > 18) ? ValidationResult.Success : new ValidationResult("Age must be 18 to be a member.");
        }
    }
}