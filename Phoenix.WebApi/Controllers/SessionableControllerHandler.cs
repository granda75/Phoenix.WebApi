using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace Phoenix.WebApi.Controllers
{
    /// <summary>
    /// I tried to use the class to manage Session in the application.
    /// </summary>
    public class SessionableControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionableControllerHandler(RouteData routeData)
            : base(routeData)
        { }
    }


}