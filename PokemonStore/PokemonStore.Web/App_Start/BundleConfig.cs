using System.Web.Optimization;

namespace PokemonStore.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/underscore.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/angular.js", "~/Scripts/angular-*", "~/Scripts/ui-grid.min.js"));// "~/Scripts/angular-*", 

            bundles.Add(new ScriptBundle("~/bundles/app").Include("~/App/app.js").IncludeDirectory("~/App/Ctrl", "*.js", true));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap.css",
                      "~/Content/app.css"));

            bundles.Add(new StyleBundle("~/Content/angularui").Include(
                      "~/Content/angular-ui.css", "~/Content/ui-grid.min.css", "~/Content/angular-ui-notification.min.css"));
        }
    }
}
