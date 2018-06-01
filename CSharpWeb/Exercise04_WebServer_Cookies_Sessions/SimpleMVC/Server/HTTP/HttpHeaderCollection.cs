using SimpleMVC.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMVC.Server.HTTP
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, ICollection<HttpHeader>> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, ICollection<HttpHeader>>();
        }

        public void AddHeader(HttpHeader header)
        {
            string key = header.Key;

            if (!this.headers.ContainsKey(key))
            {
                headers[key] = new List<HttpHeader>();
            }

            headers[key].Add(header);
        }

        public bool ContainsKey(string key)
        {
            return this.headers.ContainsKey(key);
        }

        public ICollection<HttpHeader> GetHeaders(string key)
        {
            if (!this.headers.ContainsKey(key))
            {
                return null;
            }

            return headers[key];
        }

        public override string ToString()
        {

            StringBuilder result = new StringBuilder();

            foreach (var header in this.headers)
            {
                var headerKey = header.Key;

                foreach (var headerValue in header.Value)
                {
                    result.AppendLine($"{headerKey}: {headerValue.Value}");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}