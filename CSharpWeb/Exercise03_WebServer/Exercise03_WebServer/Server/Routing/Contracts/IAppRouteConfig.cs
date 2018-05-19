using Exercise03_WebServer.Server.Enums;
using Exercise03_WebServer.Server.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.Routing.Contracts
{
    public interface IAppRouteConfig
    {
         IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes { get; }


        void AddRoute(string route, RequestHandler httpHandler);
    }
}
