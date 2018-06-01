using SimpleMVC.Server.Enums;
using SimpleMVC.Server.HTTP;

namespace SimpleMVC.Server.Contracts
{
    public interface IHttpResponse
    {
        IHttpHeaderCollection HeaderCollection { get; }

        IHttpCookieCollection CookieCollection { get; }

        HttpStatusCode StatusCode { get; }

        void AddHeader(string key, string value);

        void AddCookie(HttpCookie cookie);
    }
}