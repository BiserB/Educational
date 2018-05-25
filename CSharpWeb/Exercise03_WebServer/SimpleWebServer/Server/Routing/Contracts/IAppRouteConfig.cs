using System.Collections.Generic;
using SimpleWebServer.Server.Enums;
using SimpleWebServer.Server.Handlers;

namespace SimpleWebServer.Server.Routing.Contracts
{
    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes { get; }

        void AddRoute(string route, RequestHandler httpHandler);
    }
}