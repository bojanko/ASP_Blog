using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASP_Blog.Models;

namespace ASP_Blog.Controllers
{
    public class ProfileController : BaseController
    {
        [HttpGet]
        public ActionResult UserProfile()
        {
            return View();
        }
        /*HANDLE PASSWORD CHANGE*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserProfile(ChangePasswordViewModel pass)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!Membership.GetUser().ChangePassword(pass.old_password, pass.password))
                    {
                        throw new Exception();
                    }

                    TempData["success"] = true;
                }
                catch (Exception e)
                {
                    TempData["success"] = false;
                }

                return RedirectToAction("UserProfile", "Profile");
            }

            return View(pass);
        }
    }
}
