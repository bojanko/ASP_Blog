using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Blog.Models;
using ASP_Blog.Repository;
using System.Web.Security;
using ASP_Blog.Filters;
using ASP_Blog.Helpers;

namespace ASP_Blog.Controllers
{
    [LogFilter]
    public class PageController : BaseController
    {
        private PageRepository page_rep;
        private PostRepository post_rep;
        private CommentRepository com_rep;

        public PageController()
        {
            page_rep = new PageRepository();
            post_rep = new PostRepository();
            com_rep = new CommentRepository();
        }

        private void setPageInfo(string page)
        {
            if (page != "null")
            {
                PageModel p_model = page_rep.getPageByName(page);
                ViewBag.Page = p_model.pageName;
                ViewBag.Title = p_model.title;
                ViewBag.Text = p_model.text;
            }
        }


        public ActionResult Home()
        {
            setPageInfo("home");

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
            setPageInfo("home");

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
            setPageInfo("about");

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            setPageInfo("contact");

            MessageModel message = new MessageModel();

            if (TempData["success"] != null)
            {
                ViewBag.Success = TempData["success"];
            }

            return View(message);
        }
        /*HANDLE FORM SUBMIT*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(MessageModel mss)
        {
            if (ModelState.IsValid)
            {
                if (Mailer.Mail(mss))
                {
                    TempData["success"] = "true";
                }
                else
                {
                    TempData["success"] = "false";
                }

                return RedirectToAction("Contact", "Page");
            }

            setPageInfo("contact");

            return View(mss);
        }

        [HttpGet]
        public ActionResult ShowPost(int id)
        {
            /*GET POST*/
            PostModel post = post_rep.getPostByIdWithComments(id);

            setPageInfo("null");
            ViewBag.Post = post;
            ViewBag.Comments = post.comments;

            return View();
        }
        /*HANDLE COMMENT SUBMIT*/
        [HttpPost]
        [Authorize]
        public ActionResult ShowPost(CommentModel com, int id)
        {
            /*GET POST*/
            PostModel post = post_rep.getPostByIdWithComments(id);

            if (ModelState.IsValid)
            {
                /*ADD COMMENT*/
                com.post = post;
                if (Roles.IsUserInRole("ROLE_ADMIN"))
                {
                    com.allowed = true;
                }

                post.comments.Add(com);
                com_rep.addComment(com);

                return RedirectToAction("ShowPost", "Page");
            }

            setPageInfo("null");
            ViewBag.Post = post;
            ViewBag.Comments = post.comments;

            return View();
        }

        /*LAST 3 POSTS WIDGET*/
        public ActionResult PostsWidget()
        {
            //GET POSTS
            ViewBag.Posts = post_rep.getLastN(3);

            return View();
        }

    }
}
