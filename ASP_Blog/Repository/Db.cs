using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ASP_Blog.Models;

namespace ASP_Blog.Repository
{
    public class Db : DbContext
    {
        public Db() : base("name=DefaultConnection") 
        {
        }

        public DbSet<PageModel> Pages { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
    }
}