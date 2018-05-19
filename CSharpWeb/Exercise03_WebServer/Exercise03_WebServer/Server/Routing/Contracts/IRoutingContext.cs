using Exercise03_WebServer.Server.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.Routing.Contracts
{
    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler RequestHandler { get; }
    }
}
