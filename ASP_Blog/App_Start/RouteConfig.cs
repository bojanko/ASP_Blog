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
                url: "{action}",
                defaults: new { controller = "Page", action = "Home" }
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