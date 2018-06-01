using SimpleMVC.Server.Enums;
using System.Collections.Generic;

namespace SimpleMVC.Server.Contracts
{
    public interface IServerRouteConfig
    {
        IDictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}