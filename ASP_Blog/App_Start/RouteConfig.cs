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

            /*POSTS ROUTE*/
            routes.MapRoute(
                name: "Posts",
                url: "ShowPost/{id}",
                defaults: new { controller = "Page", action = "ShowPost" }
            );

            /*LOGIN ROUTE*/
            routes.MapRoute(
                name: "Login",
                url: "Login/{action}",
                defaults: new { controller = "Login", action = "Login"}
            );

            /*PROFILE ROUTE*/
            routes.MapRoute(
                name: "Profile",
                url: "Profile/{action}/{username}",
                defaults: new { controller = "Profile", action = "UserProfile", username = UrlParameter.Optional }
            );

            /*ADMIN ROUTE*/
            routes.MapRoute(
                name: "Admin",
                url: "Admin/{action}/{data}",
                defaults: new { controller = "Admin", action = "Moderate", data = UrlParameter.Optional }
            );

            /*PAGES ROUTE*/
            routes.MapRoute(
                name: "Pages",
                url: "{action}/{page}",
                defaults: new { controller = "Page", action = "Home", page = UrlParameter.Optional }
            );

            /*DUMMY DATA ROUTE*/
            routes.MapRoute(
                name: "DummyData",
                url: "Dummy/Data/Insert",
                defaults: new { controller = "DummyData", action = "DummyData" }
            );
        }
    }
}