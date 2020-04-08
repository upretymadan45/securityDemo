using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using sqlinj.Repository;

namespace sqlinj.Filters
{
    public class AuthFilter : IActionFilter
    {
        private readonly IUserDetail userDetail;

        public AuthFilter(IUserDetail userDetail)
        {
            this.userDetail = userDetail;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!userDetail.IsUserLoggedIn())
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Controller = "User", action = "Login" })
                );
            }
        }
    }
}