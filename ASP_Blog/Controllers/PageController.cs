using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Blog.Models;
using ASP_Blog.Repository;
using ASP_Blog.Filters;

namespace ASP_Blog.Controllers
{
    [LogFilter]
    public class PageController : Controller
    {
        PageRepository page_rep;

        public PageController()
        {
            page_rep = new PageRepository();
        }

        //
        // GET: /Home/

        public ActionResult Home()
        {
            PageModel home = page_rep.getPageByName("home");
            ViewBag.Page = home.pageName;
            ViewBag.Title = home.title;
            ViewBag.Text = home.text;

            return View();
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

    }
}
