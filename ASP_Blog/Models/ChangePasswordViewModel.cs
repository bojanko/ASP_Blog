using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ASP_Blog.Validators;

namespace ASP_Blog.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        [StringLength(Int32.MaxValue, MinimumLength = 5, ErrorMessage = "Password must be at least 5 characters long.")]
        [Display(Name = "Your old password")]
        public string old_password { get; set; }

        [Required]
        [StringLength(Int32.MaxValue, MinimumLength = 5, ErrorMessage = "Password must be at least 5 characters long.")]
        [Display(Name = "Your new password")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Confirm password doesn't match.")]
        [Display(Name = "Confirm password")]
        public string confirm_password { get; set; }
    }
}