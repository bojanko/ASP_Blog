using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASP_Blog.Models;

namespace ASP_Blog.Controllers
{
    public class LoginController : BaseController
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        /*HANDLE REGISTER*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel reg)
        {
            if (ModelState.IsValid)
            {
                Membership.CreateUser(reg.username, reg.password);
                Roles.AddUserToRole(reg.username, "ROLE_USER");

                return RedirectToAction("Login", "Login");
            }

            return View(reg);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /*HANDLE LOGIN*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel log_in)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(log_in.username, log_in.password))
                {
                    FormsAuthentication.SetAuthCookie(log_in.username, false);
                    return RedirectToAction("Home", "Page");
                }
            }

            return View(log_in);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "Page");
        }

    }
}
