using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Handlers;
using System.Collections.Generic;

namespace SimpleMVC.Server.Routing
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