using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.App.Auxiliary
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent IsReturned(this IHtmlHelper helper, bool isReturned, int loanId)
        {
            string msg = "Returned";

            if (isReturned == false)
            {
                msg = $@"<a class=""btn btn-sm bg-info text-white"" href=""/loans/Details/{loanId}"">Return</a>";
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

    }
}
