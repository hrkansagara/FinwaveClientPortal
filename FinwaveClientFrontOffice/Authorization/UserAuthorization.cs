using FinwaveClientFrontOffice.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace FinwaveClientFrontOffice.Authorization
{
    public class UserAuthorization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionHelper.CurrentUser == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
        }
    }
}