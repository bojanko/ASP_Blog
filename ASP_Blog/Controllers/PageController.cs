using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Blog.Models;
using ASP_Blog.Repository;
using ASP_Blog.Filters;
using ASP_Blog.Helpers;

namespace ASP_Blog.Controllers
{
    [LogFilter]
    public class PageController : Controller
    {
        PageRepository page_rep;
        PostRepository post_rep;

        public PageController()
        {
            page_rep = new PageRepository();
            post_rep = new PostRepository();
        }


        public ActionResult Home()
        {
            PageModel home = page_rep.getPageByName("home");
            ViewBag.Page = home.pageName;
            ViewBag.Title = home.title;
            ViewBag.Text = home.text;

            //GET POSTS
            ViewBag.Posts = post_rep.getPostsByPage(1, 5);
            //SET PAGINATOR
            Paginator<PostModel> paginator = new Paginator<PostModel>();
            paginator.setData(post_rep.getAllPosts(), 1, 5);
            ViewBag.Paginator = paginator;

            return View();
        }

        /*PAGES OF PAGINATED POSTS*/
        public ActionResult Page(int page)
        {
            PageModel home = page_rep.getPageByName("home");
            ViewBag.Page = home.pageName;
            ViewBag.Title = home.title;
            ViewBag.Text = home.text;

            //GET POSTS
            ViewBag.Posts = post_rep.getPostsByPage(page, 5);
            //SET PAGINATOR
            Paginator<PostModel> paginator = new Paginator<PostModel>();
            paginator.setData(post_rep.getAllPosts(), page, 5);
            ViewBag.Paginator = paginator;

            return View("~/Views/Page/Home.cshtml");
        }

        public ActionResult About()
        {
            PageModel about = page_rep.getPageByName("about");
            ViewBag.Page = about.pageName;
            ViewBag.Title = about.title;
            ViewBag.Text = about.text;

            return View();
        }

        public ActionResult Contact()
        {
            PageModel contact = page_rep.getPageByName("contact");
            ViewBag.Page = contact.pageName;
            ViewBag.Title = contact.title;
            ViewBag.Text = contact.text;

            return View();
        }

        public ActionResult ShowPost(int id)
        {
            /*GET POST*/
            PostModel post = post_rep.getPostById(id);

            ViewBag.Page = "post";
            ViewBag.Title = "";
            ViewBag.Text = "";
            ViewBag.Post = post;

            return View();
        }

    }
}
