using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace ASP_Blog.Filters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            Debug.WriteLine("Entering...");
        }

        public override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            Debug.WriteLine("Route: " + filterContext.HttpContext.Request.Url);
            Debug.WriteLine("Controller: " + filterContext.RouteData.Values["controller"] + "Controller");
            Debug.WriteLine("Action Method: " + filterContext.ActionDescriptor.ActionName);
            Debug.WriteLine("Entered!");
        }
    }
}
