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

        [Column("title", TypeName = "varchar")]
        public string title { get; set; }

        [Column("pagename", TypeName = "varchar")]
        public string pageName { get; set; }

        [Column("text", TypeName = "varchar")]
        public string text { get; set; }
    }
}