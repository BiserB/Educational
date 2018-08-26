using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vote.Common;

namespace Vote.App.Filters
{
    public class RedirectLoggedIn : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var isLoggedIn = context.HttpContext.User.IsInRole(RoleType.Manager);

            if (isLoggedIn)
            {
                var routeValue = new RouteValueDictionary(new { action = "Index", controller = "Activities", area = "Manager" });

                context.Result = new RedirectToRouteResult(routeValue);
            }            
        }
    }
}
