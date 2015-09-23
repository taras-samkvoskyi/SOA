using System.Web.Optimization;

namespace CarRental.Web
{
    public class BootstrapBundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap*"));
            BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/metro-bootstrap.css",
                "~/Content/bootstrap-responsive.css"
                ));
        }
    }
}
