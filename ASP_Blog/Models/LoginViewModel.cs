using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ASP_Blog.Validators;

namespace ASP_Blog.Models
{
    public class LoginViewModel
    {
        [Required]
        [ExistsValidator(ErrorMessage = "Username does not exist.")]
        [Display(Name = "Your username")]
        public string username { get; set; }

        [Required]
        [StringLength(Int32.MaxValue, MinimumLength = 5, ErrorMessage = "Password must be at least 5 characters long.")] 
        [Display(Name = "Your password")]
        public string password { get; set; }
    }
}