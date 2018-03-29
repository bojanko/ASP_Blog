using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASP_Blog.Models;

namespace ASP_Blog.Models
{
    [Table("Posts")]
    public class PostModel
    {
        [Key]
        public int id { get; set; }

        [Column("title", TypeName = "varchar")]
        public string title { get; set; }

        [Column("text", TypeName = "varchar")]
        public string text { get; set; }

        //ONE-TO-MANY
        public List<CommentModel> comments { get; set; }

        public PostModel()
        {
            comments = new List<CommentModel>();
        }
    }
}