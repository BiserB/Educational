using System.Collections.Generic;
using SimpleWebServer.Server.Handlers;

namespace SimpleWebServer.Server.Routing.Contracts
{
    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler RequestHandler { get; }
    }
}