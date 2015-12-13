using System.Web;
using System.Web.Optimization;

namespace SalesStatistics
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/gridmvc").Include(
                      "~/Scripts/gridmvc.min.js",
                      "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/highcharts").Include(
                      "~/Scripts/Highcharts-4.0.1/js/highcharts.js",
                      "~/Scripts/Highcharts-4.0.1/js/highcharts-3d.js",
                      "~/Scripts/Highcharts-4.0.1/js/modules/exporting.js"));

            bundles.Add(new StyleBundle("~/Content/gridCss").Include(
                      "~/Content/Gridmvc.css",
                      "~/Content/gridmvc.datepicker.css",
                      "~/Content/gridmvc.datepicker.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css"));

            
            BundleTable.EnableOptimizations = false;
        }
    }
}
