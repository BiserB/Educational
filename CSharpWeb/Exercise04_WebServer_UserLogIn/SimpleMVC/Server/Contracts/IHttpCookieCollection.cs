using SimpleMVC.Server.HTTP;
using System.Collections.Generic;


namespace SimpleMVC.Server.Contracts
{
    public interface IHttpCookieCollection : IEnumerable<HttpCookie>
    {
        void AddCookie(HttpCookie cookie);

        bool ContainsKey(string key);

        HttpCookie GetCookie(string key);
    }
}
