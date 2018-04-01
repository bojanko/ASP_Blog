using System.Web;
using System.Web.Optimization;

namespace ASP_Blog
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/jquery-3.3.1.min.js",
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css",
                "~/Content/Bootstrap/bootstrap.min.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}