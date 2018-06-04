using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.HTTP;
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
            string requestPath = httpRequest.Path;

            bool isSignInRequest = requestPath == Paths.logIn;
            bool loggedIn = AuthenticationCheck(httpRequest);

            if (!isSignInRequest && !loggedIn)
            {
                return new RedirectResponse(Paths.logIn);
            }

            var requestMethod = httpRequest.RequestMethod;
            
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

        private bool AuthenticationCheck(IHttpRequest httpRequest)
        {
            if (httpRequest.Session == null)
            {
                return false;
            }
            
            if (httpRequest.Session.IsLoggedIn())
            {
                return true;
            }

            return false;
        }
    }
}