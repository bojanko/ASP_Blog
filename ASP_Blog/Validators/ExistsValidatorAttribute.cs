using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using ASP_Blog.Models;

namespace ASP_Blog.Validators
{
    public class ExistsValidatorAttribute : ValidationAttribute
    {
        public ExistsValidatorAttribute()
            : base("{0} does not exist.") 
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LoginViewModel model = (LoginViewModel)validationContext.ObjectInstance;
            if(model.username != null && Membership.FindUsersByName(model.username).Count == 0)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}