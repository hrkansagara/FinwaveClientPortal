using FinwavePortal.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace FinwavePortal.Authorization
{
    public class UserAuthorization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionVars.CurrentUser == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
        }
    }
}