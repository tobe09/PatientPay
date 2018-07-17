using System.Web.Optimization;

namespace PatientPay.MvcWebApp.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/content/css").Include(
                      "~/Styles/bootstrap/css/bootstrap.min.css",
                      "~/Styles/bootstrap/css/font-awesome.min.css",
                      "~/Styles/site.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));
        }
    }
}