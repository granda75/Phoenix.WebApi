using System.Web;
using System.Web.Routing;


namespace Phoenix.WebApi.Controllers
{
    /// <summary>
    /// I tried to use the class to manage Session in the application.
    /// </summary>
    public class SessionStateRouteHandler : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            return new SessionableControllerHandler(requestContext.RouteData);
        }
    }


}
