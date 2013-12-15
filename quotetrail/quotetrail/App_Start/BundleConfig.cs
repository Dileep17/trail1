using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace quotetrail.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/quotes").Include("~/scripts/jquery-1.8.3.min.js", "~/Content/scripts/Quotes.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-unobtrusive").Include("~/Scripts/jquery.unobtrusive-ajax.min.js",
                                                                                    "~/Scripts/jquery.validate-1.10.0.min.js",
                                                                                    "~/Scripts/jquery.validate-vsdoc.js",
                                                                                    "~/Scripts/jquery.validate.unobtrusive.js"));
            bundles.Add(new StyleBundle("~/bundles/css").Include("~/content/css/common.css"));
        }
    }
}