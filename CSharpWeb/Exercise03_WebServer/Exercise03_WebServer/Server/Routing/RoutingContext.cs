using Exercise03_WebServer.Server.Routing.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Exercise03_WebServer.Server.Handlers;

namespace Exercise03_WebServer.Server.Routing
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
