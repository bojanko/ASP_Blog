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

        [Column("name", TypeName = "varchar")]
        public string name { get; set; }

        [Column("email", TypeName = "varchar")]
        public string email { get; set; }

        [Column("text", TypeName = "varchar")]
        public string text { get; set; }

        [Column("allowed", TypeName = "BIT")]
        public bool? allowed { get; set; }
    }
}