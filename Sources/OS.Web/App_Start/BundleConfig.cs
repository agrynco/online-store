using System.Web.Optimization;

namespace OS.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/jquery-ui/jquery-ui.js",
                        "~/Scripts/application/log.js",
                        "~/Scripts/jquery.dataTables.js",
                        "~/Scripts/datatables.extensions/RowReorder-1.1.1/js/dataTables.rowReorder.js",
                        "~/Scripts/bootstrap.toggle/js/bootstrap-toggle.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-switch.css",
                      "~/Content/site.css",
                      "~/Scripts/jquery-ui/jquery-ui.css",
                      "~/Content/css/jquery.dataTables.css",
                      "~/Scripts/datatables.extensions/RowReorder-1.1.1/css/rowReorder.bootstrap.css",
                      "~/Scripts/bootstrap.toggle/css/bootstrap-toggle.css"));
        }
    }
}
