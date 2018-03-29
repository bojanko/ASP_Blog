using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP_Blog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*PAGES ROUTE*/
            routes.MapRoute(
                name: "Pages",
                url: "{action}/{page}",
                defaults: new { controller = "Page", action = "Home", page = UrlParameter.Optional }
            );
            /*POSTS ROUTE*/
            routes.MapRoute(
                name: "Posts",
                url: "Posts/{post}",
                defaults: new { controller = "Page", action = "ShowPost", page = 1}
            );
            /*DUMMY DATA ROUTE*/
            routes.MapRoute(
                name: "DummyData",
                url: "Dummy/Insert",
                defaults: new { controller = "DummyData", action = "DummyData" }
            );
        }
    }
}