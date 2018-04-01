using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using ASP_Blog.Models;

namespace ASP_Blog.Validators
{
    public class UniqueValidatorAttribute : ValidationAttribute
    {
        public UniqueValidatorAttribute()
            : base("{0} is already used.") 
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            RegisterViewModel model = (RegisterViewModel)validationContext.ObjectInstance;
            if(model.username != null && Membership.FindUsersByName(model.username).Count == 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}