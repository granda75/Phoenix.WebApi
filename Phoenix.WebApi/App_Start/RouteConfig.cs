using Phoenix.WebApi.Controllers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Phoenix.WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //route for the WEB.API controller
            routes.MapHttpRoute(
                     name: "DefaultApi",
                     routeTemplate: "api/{controller}/{action}/{id}",
                     defaults: new { id = RouteParameter.Optional }
                 );
                
                //.RouteHandler = new SessionStateRouteHandler();

            //route for the MVC controller
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}
