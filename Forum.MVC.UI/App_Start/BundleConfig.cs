using System.Web;
using System.Web.Optimization;

namespace Forum.MVC.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundle script = new ScriptBundle("~/MyScript");
            script.Include("~/Scripts/jquery-3.3.1.min.js");
            script.Include("~/Scripts/jquery-ui-1.12.1.min.js");
            script.Include("~/Scripts/canvasjs.min.js");
            script.Include("~/Scripts/bootstrap.js");
            script.Include("~/Scripts/modernizr-2.8.3.js");
            StyleBundle style = new StyleBundle("~/MyStyle");
            style.Include("~/Content/W3.css");
            style.Include("~/Content/W3mod1.css");
            style.Include("~/Content/W3mod2.css");
            style.Include("~/Content/W3mod2.css");
            style.Include("~/Content/Gicon.css");
            style.Include("~/Content/GoogleIcon.css");
            style.Include("~/Content/bootstrap.css");
            style.Include("~/Content/jquery-ui.min.css");
            bundles.Add(script);
            bundles.Add(style);
        }
    }
}
