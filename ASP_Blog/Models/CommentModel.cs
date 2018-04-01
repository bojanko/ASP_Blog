using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Blog.Models
{
    [Table("Comments")]
    public class CommentModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Your name")]
        [Column("name", TypeName = "varchar")]
        public string name { get; set; }

        [EmailAddress]
        [Display(Name = "Your email")]
        [Column("email", TypeName = "varchar")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Your comment")]
        [Column("text", TypeName = "varchar")]
        public string text { get; set; }

        [Column("allowed", TypeName = "BIT")]
        public bool? allowed { get; set; }

        public PostModel post { get; set; }
    }
}