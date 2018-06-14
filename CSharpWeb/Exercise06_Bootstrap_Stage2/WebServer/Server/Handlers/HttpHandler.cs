namespace HTTPServer.Server.Handlers
{
    using Common;
    using Contracts;
    using Http.Contracts;
    using Http.Response;
    using Routing.Contracts;
    using Server.Http;
    using System;
    using System.Text.RegularExpressions;

    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig routeConfig)
        {
            CoreValidator.ThrowIfNull(routeConfig, nameof(routeConfig));

            this.serverRouteConfig = routeConfig;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            try
            {
                var request = context.Request;
                string requestPath = context.Request.Path;

                if (NotAuthenticated(request) && PathIsNotAllowed(request))
                {
                    return new RedirectResponse(Paths.Home);
                }

                var requestMethod = request.Method;

                var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

                foreach (var registeredRoute in registeredRoutes)
                {
                    var routePattern = registeredRoute.Key;
                    var routingContext = registeredRoute.Value;

                    var routeRegex = new Regex(routePattern);
                    var match = routeRegex.Match(requestPath);

                    if (!match.Success)
                    {
                        continue;
                    }

                    var parameters = routingContext.Parameters;

                    foreach (var parameter in parameters)
                    {
                        var parameterValue = match.Groups[parameter].Value;
                        context.Request.AddUrlParameter(parameter, parameterValue);
                    }

                    return routingContext.Handler.Handle(context);
                }
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }

            return new NotFoundResponse();
        }

        private bool NotAuthenticated(IHttpRequest request)
        {
            if (request.Session == null)
            {
                return true;
            }

            if (request.Session.Contains(SessionStore.CurrentUserKey))
            {
                return false;
            }

            return true;
        }

        private bool PathIsNotAllowed(IHttpRequest request)
        {
            string requestPath = request.Path;

            if (requestPath == Paths.Home || requestPath == Paths.LogIn || requestPath == Paths.Register ||
                requestPath.StartsWith(Paths.Files) || requestPath.StartsWith(Paths.Images) ||
                requestPath.StartsWith(Paths.Cart) || requestPath.StartsWith(Paths.Info) || requestPath.StartsWith(Paths.Owned))
            {
                return false;
            }
            return true;
        }
    }
}