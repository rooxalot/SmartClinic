using System.Web;
using System.Web.Optimization;

namespace SmartClinic.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //SmartClinic CSS Bundles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/SmartClinic/css").Include(
                "~/Content/css/custom.css",
                "~/Content/css/fonts/css/font-awesome.min.css",
                "~/Content/css/animate.min.css",
                "~/Content/css/icheck/flat/green.css",
                "~/Content/css/maps/jquery-jvectormap-2.0.3.css",
                "~/Content/css/floatexamples.css"));
        }
    }
}
