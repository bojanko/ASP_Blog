using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASP_Blog.Models;
using ASP_Blog.Repository;
using ASP_Blog.Helpers;

namespace ASP_Blog.Controllers
{
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminController : BaseController
    {
        private CommentRepository com_rep;
        private AdminRequestRepository adm_req_rep;
        private PostRepository post_rep;
        private PageRepository page_rep;

        private Paginator<PostModel> paginator;

        public AdminController()
        {
            com_rep = new CommentRepository();
            adm_req_rep = new AdminRequestRepository();
            post_rep = new PostRepository();
            page_rep = new PageRepository();

            paginator = new Paginator<PostModel>();
        }

        public ActionResult Moderate()
        {
            /*GET UNMODERATED COMMENTS*/
            ViewBag.Comments = com_rep.getAllNonmoderated();

            return View();
        }
        /*HANDLE COMMENT APPROVAL*/
        public ActionResult ModerateAllow(int data)
        {
            CommentModel comment = com_rep.getCommentById(data);
            comment.allowed = true;
            com_rep.updateComment(comment);

            return RedirectToAction("Moderate", "Admin");
        }
        /*HANDLE COMMENT DENIAL*/
        public ActionResult ModerateDeny(int data)
        {
            CommentModel comment = com_rep.getCommentById(data);
            comment.allowed = false;
            com_rep.updateComment(comment);

            return RedirectToAction("Moderate", "Admin");
        }


        public ActionResult AdminRequests()
        {
            /*GET PENDING REQUESTS*/
            ViewBag.Requests = adm_req_rep.getAllPendingAdminRequests();

            return View();
        }
        /*APPROVE REQUEST*/
        public ActionResult AdminRequestGrant(int data)
        {
            AdminRequestModel request = adm_req_rep.getAdminRequestById(data);
            Roles.AddUserToRole(request.username, "ROLE_ADMIN");
            request.handled = true;
            adm_req_rep.updateAdminRequest(request);

            return RedirectToAction("AdminRequests", "Admin");
        }
        /*REJECT REQUEST*/
        public ActionResult AdminRequestReject(int data)
        {
            AdminRequestModel request = adm_req_rep.getAdminRequestById(data);
            request.handled = true;
            adm_req_rep.updateAdminRequest(request);

            return RedirectToAction("AdminRequests", "Admin");
        }


        public ActionResult Posts()
        {
            /*GET POSTS*/
            paginator.setData(post_rep.getAllPosts(), 1, 10);
            ViewBag.Posts = post_rep.getPostsByPage(1, 10);
            ViewBag.Paginator = paginator;

            return View();
        }
        public ActionResult PostsPage(int data)
        {
            /*GET POSTS*/
            paginator.setData(post_rep.getAllPosts(), data, 10);
            ViewBag.Posts = post_rep.getPostsByPage(data, 10);
            ViewBag.Paginator = paginator;

            return View("~/Views/Admin/Posts.cshtml");
        }
        /*DELETE POST*/
        public ActionResult DeletePost(int data)
        {
            PostModel post = post_rep.getPostById(data);
            post_rep.deletePost(post);

            return RedirectToAction("Posts", "Admin");
        }
        /*EDIT POST*/
        [HttpGet]
        public ActionResult EditPost(int data)
        {
            /*GET POST*/
            PostModel post = post_rep.getPostById(data);
            ViewBag.Action = "Edit";

            return View("~/Views/Admin/PostForm.cshtml", post);
        }
        /*HANDLE EDIT*/
        [HttpPost]
        public ActionResult EditPost(PostModel post, int data)
        {
            if (ModelState.IsValid)
            {
                PostModel db_post = post_rep.getPostById(data);
                db_post.title = post.title;
                db_post.text = post.text;
                post_rep.updatePost(db_post);

                return RedirectToAction("Posts", "Admin");
            }
            ViewBag.Action = "Edit";

            return View("~/Views/Admin/PostForm.cshtml", post);
        }
        /*NEW POST*/
        [HttpGet]
        public ActionResult NewPost()
        {
            ViewBag.Action = "Insert";

            return View("~/Views/Admin/PostForm.cshtml");
        }
        /*HANDLE INSERT*/
        [HttpPost]
        public ActionResult NewPost(PostModel post)
        {
            if (ModelState.IsValid)
            {
                post_rep.addPost(post);

                return RedirectToAction("Posts", "Admin");
            }

            ViewBag.Action = "Insert";

            return View("~/Views/Admin/PostForm.cshtml");
        }

        /*EDIT PAGE*/
        [HttpGet]
        public ActionResult EditPage(string data)
        {
            PageModel page = page_rep.getPageByName(data);

            return View("~/Views/Admin/PageForm.cshtml", page);
        }
        /*HANDLE PAGE UPDATE*/
        [HttpPost]
        public ActionResult EditPage(PageModel page, string data)
        {
            if (ModelState.IsValid)
            {
                PageModel db_page = page_rep.getPageByName(data);
                db_page.title = page.title;
                db_page.text = page.text;
                page_rep.updatePage(db_page);

                RedirectToAction("EditPage", "Admin", new { data = data });
            }

            return View("~/Views/Admin/PageForm.cshtml", page);
        }
    }
}
