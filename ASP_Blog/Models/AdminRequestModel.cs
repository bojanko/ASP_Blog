using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Blog.Models
{
    [Table("Admin_Requests")]
    public class AdminRequestModel
    {
        [Key]
        public int id { get; set; }

        [Column("username", TypeName = "varchar")]
        public string username { get; set; }

        [Column("handled", TypeName = "BIT")]
        public bool handled { get; set; }
    }
}