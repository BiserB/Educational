﻿using System;
using System.Collections.Generic;
using SimpleWebServer.Server.Enums;
using SimpleWebServer.Server.Handlers;
using SimpleWebServer.Server.Routing.Contracts;

namespace SimpleWebServer.Server.Routing
{
    public class AppRouteConfig : IAppRouteConfig
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>>();

            var requestMethods = Enum.GetValues(typeof(HttpRequestMethod));

            foreach (var reqMethod in requestMethods)
            {
                var method = (HttpRequestMethod)reqMethod;
                routes[method] = new Dictionary<string, RequestHandler>();
            }
        }

        public IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes => this.routes;

        public void AddRoute(string route, RequestHandler httpHandler)
        {
            var handlerName = httpHandler.GetType().Name.ToLower();

            if (handlerName.Contains("get"))
            {
                this.routes[HttpRequestMethod.GET].Add(route, httpHandler);
            }
            else if (handlerName.Contains("post"))
            {
                this.routes[HttpRequestMethod.POST].Add(route, httpHandler);
            }
            else
            {
                throw new InvalidOperationException("Invalid handler!");
            }
        }
    }
}