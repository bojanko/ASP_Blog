using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
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
            context.Entry<PostModel>(c.post).State = EntityState.Modified;
            context.Comments.Add(c);
            context.SaveChanges();
        }

        public void updateComment(CommentModel c)
        {
            context.Entry<PostModel>(c.post).State = EntityState.Unchanged;
            context.Entry<CommentModel>(c).State = EntityState.Modified;
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