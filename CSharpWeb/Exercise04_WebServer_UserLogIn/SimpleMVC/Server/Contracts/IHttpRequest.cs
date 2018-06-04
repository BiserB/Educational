using SimpleMVC.Server.Enums;
using SimpleMVC.Server.HTTP;
using System.Collections.Generic;

namespace SimpleMVC.Server.Contracts
{
    public interface IHttpRequest
    {
        Dictionary<string, string> FormData { get; }

        IHttpHeaderCollection HeaderCollection { get; }

        IHttpCookieCollection CookieCollection { get; }

        IHttpSession Session { get; set; }

        string Path { get; }

        Dictionary<string, string> QueryParameters { get; }

        HttpRequestMethod RequestMethod { get; }

        string Url { get; }

        Dictionary<string, string> UrlParameters { get; }

        void AddUrlParameter(string key, string value);
    }
}