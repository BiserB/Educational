using System.Collections.Generic;
using SimpleWebServer.Server.Handlers;
using SimpleWebServer.Server.Routing.Contracts;

namespace SimpleWebServer.Server.Routing
{
    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(IEnumerable<string> parameters, RequestHandler requestHandler)
        {
            this.Parameters = parameters;
            this.RequestHandler = requestHandler;
        }

        public IEnumerable<string> Parameters { get; }

        public RequestHandler RequestHandler { get; }
    }
}