using System.Web;
using System.Web.Mvc;
using ASP_Blog.Filters;

namespace ASP_Blog
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}