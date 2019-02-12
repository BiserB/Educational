using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BookLibrary.App.Filters
{
    public class ExceptionLoggingFilter : IExceptionFilter
    {
        private ILogger<ExceptionLoggingFilter> logger;

        public ExceptionLoggingFilter(ILogger<ExceptionLoggingFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.ExceptionHandled = true;

                var type = context.Exception.GetType().Name;

                var stack = context.Exception.StackTrace;

                this.logger.LogError($"Unhandled EXCEPTION: {type} / {stack}");

                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}