using System.Web;
using System.Web.Optimization;

namespace SmartClinic.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Default Bundles

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css"));

            #endregion

            #region Custom Bundles

            //SmartClinic CSS Bundles
            bundles.Add(new StyleBundle("~/SmartClinic/css").Include(
                    "~/Content/SmartClinic/fonts/css/font-awesome.min.css",
                    "~/Content/SmartClinic/css/animate.min.css",
                    "~/Content/SmartClinic/css/custom.css",
                    "~/Content/SmartClinic/css/maps/jquery-jvectormap-2.0.3.css",
                    "~/Content/SmartClinic/css/icheck/flat/green.css",
                    "~/Content/SmartClinic/css/floatexamples.css"
                    ));


            //SmartClinic JS Bundles
            bundles.Add(new ScriptBundle("~/SmartClinic/js").Include(
                    "~/Scripts/SmartClinic/js/progressbar/bootstrap-progressbar.min.js",
                    "~/Scripts/SmartClinic/js/icheck/icheck.min.js",
                    "~/Scripts/SmartClinic/js/gauge/gauge.min.js",
                    "~/Scripts/SmartClinic/js/moment/moment.min.js",
                    "~/Scripts/SmartClinic/js/datepicker/daterangepicker.js",
                    "~/Scripts/SmartClinic/js/chartjs/chart.min.js",
                    "~/Scripts/SmartClinic/js/sparkline/jquery.sparkline.min.js",
                    "~/Scripts/SmartClinic/js/custom.js",
                    "~/Scripts/SmartClinic/js/skycons/skycons.min.js",
                    "~/Scripts/SmartClinic/js/flot/jquery.flot.js",
                    "~/Scripts/SmartClinic/js/flot/jquery.flot.pie.js",
                    "~/Scripts/SmartClinic/js/flot/jquery.flot.orderBars.js",
                    "~/Scripts/SmartClinic/js/flot/jquery.flot.time.min.js",
                    "~/Scripts/SmartClinic/js/flot/date.js",
                    "~/Scripts/SmartClinic/js/flot/jquery.flot.spline.js",
                    "~/Scripts/SmartClinic/js/flot/jquery.flot.stack.js",
                    "~/Scripts/SmartClinic/js/flot/curvedLines.js",
                    "~/Scripts/SmartClinic/js/flot/jquery.flot.resize.js",
                    "~/Scripts/SmartClinic/js/pace/pace.min.js"
                ));

            #endregion
        }
    }
}
