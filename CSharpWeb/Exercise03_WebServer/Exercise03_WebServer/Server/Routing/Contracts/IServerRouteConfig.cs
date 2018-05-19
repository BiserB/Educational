using Exercise03_WebServer.Server.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.Routing.Contracts
{
    public interface IServerRouteConfig
    {
        IDictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}
