using SimpleMVC.Server.Enums;
using SimpleMVC.Server.Handlers;
using System;
using System.Collections.Generic;

namespace SimpleMVC.Server.Contracts
{
    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes { get; }

        void Get(string route, Func<IHttpRequest, IHttpResponse> handler);

        void Post(string route, Func<IHttpRequest, IHttpResponse> handler);

        void AddRoute(string route, HttpRequestMethod method, RequestHandler handler);
    }
}