using System.Web.Optimization;

namespace Apsis.Bowling.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/scripts/angular.js"));
        }
    }
}