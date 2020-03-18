using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ShoppingCart.Domain.Entities;
using ShoppingCart.WebUI.Binders;

namespace ShoppingCart.WebUI
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
