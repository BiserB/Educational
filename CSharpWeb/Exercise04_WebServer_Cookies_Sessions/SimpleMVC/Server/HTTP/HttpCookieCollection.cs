using SimpleMVC.Server.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMVC.Server.HTTP
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly Dictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void AddCookie(HttpCookie cookie)
        {
            string key = cookie.Key;
            
            cookies[key] = cookie;
        }

        public bool ContainsKey(string key)
        {
            return this.cookies.ContainsKey(key);           
        }

        public HttpCookie GetCookie(string key)
        {
            if (this.ContainsKey(key))
            {
                return cookies[key];
            }
            return null;
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            return this.cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
