using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP_Blog.Models
{
    public class MessageModel
    {
        [Display(Name = "Your name")]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Your email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string message { get; set; }
    }
}