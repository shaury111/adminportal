using System.Web;
using System.Web.Optimization;

namespace new_loginsystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        //public static void RegisterBundles(BundleCollection bundles)
        //{
        //    bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
        //                "~/Scripts/jquery-{version}.js"));

        //    bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
        //                "~/Scripts/jquery.validate*"));

        //    // Use the development version of Modernizr to develop with and learn from. Then, when you're
        //    // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        //    bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
        //                "~/Scripts/modernizr-*"));

        //    bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
        //              "~/Scripts/bootstrap.js",
        //              "~/Scripts/respond.js"
        //              ));

        //    bundles.Add(new StyleBundle("~/Content/css").Include(
        //              "~/Content/bootstrap.css",
        //              "~/Content/site.css"));


        //    bundles.Add(new StyleBundle("~/Content/style").Include(
        //              "~/css/normalize.css",
        //              "~/css/main.css",
        //               "~/css/bootstrap.min.css",
        //                "~/css/all.min.css",
        //                 "~/fonts/flaticon.css",
        //                  "~/css/fullcalendar.min.css",
        //                   "~/css/animate.min.css",
        //                   "~/css/select2.min.css",
        //                   "~/css/jquery.dataTables.min.css",
        //                    "~/style.css"

        //              ));


        //    bundles.Add(new StyleBundle("~/Content/webstyle").Include(
        //             "~/www/assets/css/bootstrap.min.css",
        //             "~/www/assets/css/all.min.css",
        //              "~/www/assets/css/font.css",
        //               "~/www/assets/css/swiper.min.css",
        //                "~/www/assets/css/style.css",
        //                 "~/www/assets/images/fav.png"

        //             ));
        //}

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/Calender").Include("~/js/fullcalendar.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/Chart").Include("~/js/Chart.min.js"));
            //bundles.Add(new ScriptBundle("~/bundles/Chart").Include("~/js/Chart.min.js"));



            bundles.Add(new StyleBundle("~/SiteContentLogin/css").Include(
                     "~/css/normalize.css",
                      "~/css/main.css",
                     "~/css/bootstrap.min.css",
                     "~/css/all.min.css",
                     "~/fonts/flaticon.css",
                     "~/css/animate.min.css",
                     "~/css/style.css"
                     ));

            //Login Js



            bundles.Add(new ScriptBundle("~/AccountLogin/LoginJs").Include(
                   "~/js/jquery-3.3.1.min.js",
                   "~/js/plugins.js",
                   "~/js/popper.min.js",
                   "~/js/bootstrap.min.js",
                   "~/js/jquery.scrollUp.min.js",
                   "~/js/main.js"
                   ));
            bundles.Add(new ScriptBundle("~/MyCommonJs/CommonJs").Include(
                   "~/js/jquery-3.3.1.min.js",
                   "~/js/plugins.js",
                   "~/js/popper.min.js",
                   "~/js/bootstrap.min.js",
                   "~/js/jquery.counterup.min.js",
                   "~/js/jquery.waypoints.min.js",
                    "~/js/moment.min.js",
                   "~/js/jquery.scrollUp.min.js",
                   "~/js/main.js"
                   ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));





            bundles.Add(new StyleBundle("~/SiteContentLogin/css").Include(
                      "~/css/normalize.css",
                       "~/css/main.css",
                      "~/css/bootstrap.min.css",
                      "~/css/all.min.css",
                      "~/fonts/flaticon.css",
                      "~/css/animate.min.css",
                      "~/css/style.css"
                      ));

            //Login Js



            bundles.Add(new ScriptBundle("~/AccountLogin/LoginJs").Include(
                   "~/js/jquery-3.3.1.min.js",
                   "~/js/plugins.js",
                   "~/js/popper.min.js",
                   "~/js/bootstrap.min.js",
                   "~/js/jquery.scrollUp.min.js",
                   "~/js/main.js"
                   ));





            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            BundleTable.EnableOptimizations = true;

            //bundles.IgnoreList.Clear();
        }
    }
}
