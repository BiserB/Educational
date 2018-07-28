using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BookLibrary.App.Filters
{
    public class LoggingInfoFilter : IActionFilter, IPageFilter
    {
        private ILogger<LoggingInfoFilter> logger;
        private Stopwatch stopwatch;

        public LoggingInfoFilter(ILogger<LoggingInfoFilter> logger, Stopwatch stopwatch)
        {
            this.logger = logger;
            this.stopwatch = stopwatch;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var method = context.HttpContext.Request.Method;
            var action = context.ActionDescriptor.DisplayName;
            var state = context.ModelState.IsValid;

            this.logger.LogInformation($"Executing {method} {action}");
            this.logger.LogInformation($"Model state is valid: {state}");

            stopwatch.Restart();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var method = context.HttpContext.Request.Method;
            var action = context.ActionDescriptor.DisplayName;

            this.stopwatch.Stop();

            var time = this.stopwatch.Elapsed.TotalMilliseconds;

            this.logger.LogInformation($"EXECUTED {method} {action} in {time}");
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var method = context.HttpContext.Request.Method;
            var action = context.ActionDescriptor.DisplayName;
            var state = context.ModelState.IsValid;

            this.logger.LogInformation($"Executing {method} {action}");
            this.logger.LogInformation($"Model state is valid: {state}");

            stopwatch.Restart();
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            var method = context.HttpContext.Request.Method;
            var action = context.ActionDescriptor.DisplayName;
            var time = this.stopwatch.ElapsedMilliseconds;

            this.stopwatch.Stop();

            this.logger.LogInformation($"EXECUTED {method} {action} in {time}");
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            // void
        }
    }
}