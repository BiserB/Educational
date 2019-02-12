using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookLibrary.App.Auxiliary
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent IsReturned(this IHtmlHelper helper, bool isReturned, int loanId, string itemType)
        {
            string msg = "Returned";

            if (isReturned == false)
            {
                msg = $@"<a class=""btn btn-sm bg-info text-white"" href=""/Loans/Details?id={loanId}&type={itemType}"">Return</a>";
            }

            return new HtmlString(msg);
        }

        public static IHtmlContent IsOverdue(this IHtmlHelper helper, string status)
        {
            string statusColored = $@"<span class=""alert alert-info"">{status}</span>";

            if (status == "Overdue")
            {
                statusColored = $@"<span class=""alert alert-danger"">{status}</span>";
            }

            return new HtmlString(statusColored);
        }

        public static IHtmlContent IsAuthenticated(this IHtmlHelper helper, HttpContext context)
        {
            string cookie = context.Request.Cookies[SessionKeys.UserKey];

            string button = @"<a href=""/Users/Login"" class=""nav-item btn btn-secondary  m-1"">Login</a>";

            if (cookie != null)
            {
                var key = context.Session.GetString(cookie);

                if (key == SessionKeys.UserKey)
                {
                    button = @"<a href=""/Users/Logout"" class=""nav-item btn btn-secondary  m-1"">Logout</a>";
                }
            }

            return new HtmlString(button);
        }
    }
}