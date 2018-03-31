using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASP_Blog.Models;
using ASP_Blog.Repository;

namespace ASP_Blog.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private AdminRequestRepository req_rep;

        public ProfileController()
        {
            req_rep = new AdminRequestRepository();
        }


        [HttpGet]
        public ActionResult UserProfile()
        {
            if (!req_rep.requestExists(Membership.GetUser().UserName))
            {
                ViewBag.AdminRequest = true;
            }

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

            if (!req_rep.requestExists(Membership.GetUser().UserName))
            {
                ViewBag.AdminRequest = true;
            }

            return View(pass);
        }

        [HttpGet]
        public ActionResult AdminRequest()
        {
            /*ADD ADMIN REQUEST*/
            AdminRequestModel request = new AdminRequestModel();
            request.username = Membership.GetUser().UserName;
            request.handled = false;
            req_rep.addAdminRequest(request);

            return RedirectToAction("UserProfile", "Profile");
        }
    }
}
