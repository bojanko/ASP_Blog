using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ASP_Blog.Repository;
using ASP_Blog.Models;

namespace ASP_Blog.Repository
{
    public class PostRepository
    {
        private Db context;

        public PostRepository()
        {
            context = new Db();
        }

        public void addPost(PostModel p)
        {
            context.Posts.Add(p);
            context.SaveChanges();
        }

        public void updatePost(PostModel p)
        {
            foreach (CommentModel c in p.comments)
            {
                context.Entry<CommentModel>(c).State = EntityState.Unchanged;
            }
            context.Entry<PostModel>(p).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void deletePost(PostModel p)
        {
            context.Posts.Remove(p);
            context.SaveChanges();
        }

        public PostModel getPostById(int id)
        {
            return context.Posts.Find(id);
        }

        public PostModel getPostByIdWithComments(int id)
        {
            return (from p in context.Posts.Include("comments") where p.id == id select p).Single();
        }

        public List<PostModel> getAllPosts()
        {
            return (from p in context.Posts orderby p.id descending select p).ToList<PostModel>(); 
        }

        public List<PostModel> getPostsByPage(int page = 1, int per_page = 5)
        {
            List<PostModel> all_posts = getAllPosts();
            return all_posts.GetRange((page - 1) * per_page,
                all_posts.Count - ((page - 1) * per_page) >= per_page ? per_page : all_posts.Count - ((page - 1) * per_page)); 
        }

        public List<PostModel> getLastN(int n)
        {
            return (from p in context.Posts orderby p.id descending select p).Take(n).ToList<PostModel>();
        }
    }
}