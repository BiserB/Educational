using BookLibrary.App.Auxiliary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace BookLibrary.App.Filters
{
    public class AuthorizeAttribute : Attribute, IActionFilter, IPageFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string cookie = context.HttpContext.Request.Cookies[SessionKeys.UserKey];

            if (cookie != null)
            {
                string key = context.HttpContext.Session.GetString(cookie);

                if (key == SessionKeys.UserKey)
                {
                    return;
                }
            }

            context.Result = new RedirectToActionResult("Login", "Users", null);
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            string cookie = context.HttpContext.Request.Cookies[SessionKeys.UserKey];

            if (cookie != null)
            {
                string key = context.HttpContext.Session.GetString(cookie);

                if (key == SessionKeys.UserKey)
                {
                    return;
                }
            }

            context.Result = new RedirectToActionResult("Login", "Users", null);
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            // void
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            // void
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // void
        }
    }
}