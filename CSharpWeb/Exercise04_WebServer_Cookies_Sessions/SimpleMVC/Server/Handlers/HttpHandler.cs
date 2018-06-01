using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.HTTP.Response;
using System;
using System.Text.RegularExpressions;

namespace SimpleMVC.Server.Handlers
{
    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            this.serverRouteConfig = serverRouteConfig ?? throw new ArgumentNullException("serverRouteConfig is null");
        }

        public IHttpResponse Handle(IHttpRequest httpRequest)
        {
            var requestMethod = httpRequest.RequestMethod;
            var requestPath = httpRequest.Path;
            var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

            foreach (var registeredRoute in registeredRoutes)
            {
                string routePattern = registeredRoute.Key;
                IRoutingContext routingContext = registeredRoute.Value;

                Regex routeRegex = new Regex(routePattern);
                Match match = routeRegex.Match(requestPath);

                if (!match.Success)
                {
                    continue;
                }

                var parameters = routingContext.Parameters;

                foreach (string parameter in parameters)
                {
                    string parameterValue = match.Groups[parameter].Value;

                    httpRequest.AddUrlParameter(parameter, parameterValue);
                }

                IHttpResponse response = routingContext.RequestHandler.Handle(httpRequest);

                return response;
            }

            return new NotFoundResponse();
        }
    }
}