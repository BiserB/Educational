using Exercise03_WebServer.Server.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.HTTP.Contracts
{
    public interface IHttpRequest
    {
         Dictionary<string, string> FormData { get; }

         HttpHeaderCollection HeaderCollection { get; }

        string Path { get; }

        Dictionary<string, string> QueryParameters { get; }

        HttpRequestMethod RequestMethod { get; }

        string Url { get; }

        Dictionary<string, string> UrlParameters { get; }

        void AddUrlParameter(string key, string value);
    }
}
