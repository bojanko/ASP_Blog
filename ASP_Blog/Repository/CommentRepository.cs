using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_Blog.Repository;
using ASP_Blog.Models;

namespace ASP_Blog.Repository
{
    public class CommentRepository
    {
        private Db context;

        public CommentRepository()
        {
            context = new Db();
        }

        public void addComment(CommentModel c)
        {
            context.Comments.Add(c);
            context.SaveChanges();
        }

        public void updateComment()
        {
            context.SaveChanges();
        }

        public void deleteComment(CommentModel c)
        {
            context.Comments.Remove(c);
            context.SaveChanges();
        }

        public CommentModel getCommentById(int id)
        {
            return context.Comments.Find(id);
        }
    }
}