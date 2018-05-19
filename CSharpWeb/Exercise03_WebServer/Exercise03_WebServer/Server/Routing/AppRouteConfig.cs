using Exercise03_WebServer.Server.Routing.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Exercise03_WebServer.Server.Enums;
using Exercise03_WebServer.Server.Handlers;

namespace Exercise03_WebServer.Server.Routing
{
    public class AppRouteConfig : IAppRouteConfig
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>>();

            var requestMethods = Enum.GetValues(typeof(HttpRequestMethod));

            foreach (var reqmethod in requestMethods)
            {
                var method = (HttpRequestMethod)reqmethod;
                routes[method] = new Dictionary<string, RequestHandler>();
            }

        }

        public IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes => this.routes;

        public void AddRoute(string route, RequestHandler httpHandler)
        {
            var handlerName = httpHandler.GetType().Name.ToLower();

            if (handlerName.Contains("get"))
            {
                this.routes[HttpRequestMethod.GET].Add(route, httpHandler);
            }
            else if (handlerName.Contains("post"))
            {
                this.routes[HttpRequestMethod.POST].Add(route, httpHandler);
            }
            else
            {
                throw new InvalidOperationException("Invalid handler!");
            }
        }
    }
}
