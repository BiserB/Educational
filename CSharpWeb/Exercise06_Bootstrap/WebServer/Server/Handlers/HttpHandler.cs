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
                string requestPath = context.Request.Path;

                bool isRegisterRequest = requestPath == Paths.LogIn;
                bool isSignInRequest = requestPath == Paths.Register;
                bool isLoggedIn = AuthenticationCheck(context.Request);

                if (!isRegisterRequest && !isSignInRequest && !isLoggedIn)
                {
                    return new RedirectResponse(Paths.LogIn);
                }

                var requestMethod = context.Request.Method;

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

        private bool AuthenticationCheck(IHttpRequest httpRequest)
        {
            if (httpRequest.Session == null)
            {
                return false;
            }

            if (httpRequest.Session.Contains(SessionStore.CurrentUserKey))
            {
                return true;
            }

            return false;
        }
    }
}