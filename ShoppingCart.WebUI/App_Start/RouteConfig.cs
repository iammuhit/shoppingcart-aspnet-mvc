using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingCart.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "", new { controller = "Product", action = "List", category = (string) null, page = 1 });
            routes.MapRoute(null, "Products/{page}", new { controller = "Product", action = "List", category = (string) null }, new { page = @"\d+" });
            routes.MapRoute(null, "Products/{category}", new { controller = "Product", action = "List", page = 1 });
            routes.MapRoute(null, "Products/{category}/{page}", new { controller = "Product", action = "List" }, new { page = @"\d+" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
