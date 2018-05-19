using Exercise03_WebServer.Server.Routing.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Exercise03_WebServer.Server.Enums;
using System.Text.RegularExpressions;

namespace Exercise03_WebServer.Server.Routing
{
    public class ServerRouteConfig : IServerRouteConfig
    {
        private readonly IDictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> routes;

        public ServerRouteConfig(IAppRouteConfig appRouteConfig)
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>>();

            var requestMethods = Enum.GetValues(typeof(HttpRequestMethod));

            foreach (var reqMethod in requestMethods)
            {
                var method = (HttpRequestMethod)reqMethod;
                routes[method] = new Dictionary<string, IRoutingContext>();
            }

            this.InitializeServerConfig(appRouteConfig);
        }

        public IDictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes => this.routes;
        
        private void InitializeServerConfig(IAppRouteConfig appRouteConfig)
        {
            foreach (var registeredRoute in appRouteConfig.Routes)
            {
                var requestMethod = registeredRoute.Key;
                var routesWithHandlers = registeredRoute.Value;

                foreach (var routeWithHandler in routesWithHandlers)
                {
                    var route = routeWithHandler.Key;
                    var handler = routeWithHandler.Value;

                    var parameters = new List<string>();

                    string parsedRouteRegex = this.ParseRoute(route, parameters);

                    var routingContext = new RoutingContext(parameters, handler);

                    this.routes[requestMethod].Add(parsedRouteRegex, routingContext);
                }
            }
        }

        private string ParseRoute(string route, List<string> parameters)
        {
            StringBuilder result = new StringBuilder();

            result.Append("^");

            if (route == "/")
            {
                result.Append("?$");
                return result.ToString();
            }

            string[] tokens = route.Split('/');

            this.ParseTokens(parameters, tokens, result);

            return result.ToString();
        }

        private void ParseTokens(List<string> parameters, string[] tokens, StringBuilder result)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                string currentToken = tokens[i];
                string end = "";

                if (i == tokens.Length - 1)
                {
                    end = "$";
                }
                else
                {
                    end = "/";
                }

                if (!currentToken.StartsWith("{") && currentToken.EndsWith("}"))
                {
                    result.Append($"{currentToken}{end}");
                    continue;
                }

                string pattern = @"<\\w+>";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(currentToken);

                if (!match.Success)
                {
                    continue;
                }

                string paramName = match.Groups[0].Value.Substring(1, match.Groups[0].Length - 2);

                parameters.Add(paramName);

                result.Append($"{currentToken.Substring(1, currentToken.Length - 2)}{end}");
            }
        }
    }
}
