using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Blog.Models
{
    [Table("Pages")]
    public class PageModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Page title")]
        [Column("title", TypeName = "varchar")]
        public string title { get; set; }

        [Column("pagename", TypeName = "varchar")]
        public string pageName { get; set; }

        [Required]
        [Display( Name = "Page text" )]
        [Column("text", TypeName = "varchar")]
        public string text { get; set; }
    }
}