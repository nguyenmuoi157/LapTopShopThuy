using System.Web;
using System.Web.Optimization;

namespace LaptopShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/bundles/shopping")
                                .IncludeDirectory("~/assets/Client/dest/js", "*.js", true));
            //.Include(
            //                    "~/assets/Client/dest/js/custom.js",
            //                    "~/assets/Client/dest/js/custom2.js",
            //                    "~/assets/Client/dest/js/jquery.carouFredSel-6.0.0-packed.js",
            //                    "~/assets/Client/dest/js/jquery.countTo.js",
            //                    "~/assets/Client/dest/js/jquery.dlmenu.js",
            //                    "~/assets/Client/dest/js/jquery.isotope.min.js",
            //                    "~/assets/Client/dest/js/jquery.nivo.slider.js",
            //                    "~/assets/Client/dest/js/portfolio.js",
            //                    "~/assets/Client/dest/js/scripts.min.js",
            //                    "~/assets/Client/dest/js/waypoints.min.js",
            //                    "~/assets/Client/dest/js/wow.min.js")
        }
    }
}
