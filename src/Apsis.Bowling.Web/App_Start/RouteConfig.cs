using System.Web.Mvc;
using System.Web.Routing;

namespace Apsis.Bowling.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.AppendTrailingSlash = false;
            routes.LowercaseUrls = true;

            routes.MapMvcAttributeRoutes();
        }
    }
}
