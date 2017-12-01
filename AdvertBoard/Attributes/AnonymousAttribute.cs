using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace AdvertBoard.Attributes
{
    public class AnonymousAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Category", action = "GetCategories" }));
            }
        }
    }
}