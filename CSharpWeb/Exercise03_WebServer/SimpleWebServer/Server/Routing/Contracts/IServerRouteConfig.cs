using System.Collections.Generic;
using SimpleWebServer.Server.Enums;

namespace SimpleWebServer.Server.Routing.Contracts
{
    public interface IServerRouteConfig
    {
        IDictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}