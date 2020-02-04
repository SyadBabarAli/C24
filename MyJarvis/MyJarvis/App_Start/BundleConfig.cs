using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MyJarvis.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-{version}.intellisense.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/highcharts.js",
                "~/Scripts/no-data-to-display.js",
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/dataTables.bootstrap.min.js",
                "~/Scripts/main.js"
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/frontpage").Include(
                "~/Scripts/highcharts-more.js",
                "~/Scripts/frontpage.js"
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/prioritypage").Include(
                "~/Scripts/data.js",
                "~/Scripts/drilldown.js",
                "~/Scripts/prioritypage.js"
                ));
            
            bundles.Add(new ScriptBundle("~/bundles/pendingpage").Include(
                "~/Scripts/pendingpage.js"
                ));
            
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/reset.css",
                "~/Content/dataTables.bootstrap.min.css",
                "~/Content/main.css"
                ));
            
            BundleTable.EnableOptimizations = true;
        }
    }
}