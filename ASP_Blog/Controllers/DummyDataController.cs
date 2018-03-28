﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Blog.Repository;
using ASP_Blog.Models;

namespace ASP_Blog.Controllers
{
    public class DummyDataController : Controller
    {
        PageRepository page_rep;

        public DummyDataController()
        {
            page_rep = new PageRepository();
        }

        //
        // GET: /DummyData/

        public ActionResult DummyData()
        {
            /*INSERT INITIAL PAGE DATA*/
            /*
            PageModel home = new PageModel();
            home.pageName = "home";
            home.title = "Welcome to home page!";
            home.text = "This is home page of ASP.NET powered blog!";
            page_rep.addPage(home);

            PageModel about = new PageModel();
            about.pageName = "about";
            about.title = "Welcome to about page!";
            about.text = "This is about page of ASP.NET powered blog!";
            page_rep.addPage(about);

            PageModel contact = new PageModel();
            contact.pageName = "contact";
            contact.title = "Welcome to contact page!";
            contact.text = "This is contact page of ASP.NET powered blog!";
            page_rep.addPage(contact);
            */

            return View();
        }

    }
}