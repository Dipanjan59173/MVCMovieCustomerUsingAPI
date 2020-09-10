using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerWithAuthMVC_app.Models
{
    public class Min18YrsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.DOB == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.DOB.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer Should be at least 18 years old to be members ");
                return base.IsValid(value, validationContext);
 
        }
    }
        
        
}