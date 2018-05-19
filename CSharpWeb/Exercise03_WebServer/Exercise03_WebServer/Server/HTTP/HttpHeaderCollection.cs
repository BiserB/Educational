using Exercise03_WebServer.Server.HTTP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise03_WebServer.Server.HTTP
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            if (header == null)
            {
                throw new ArgumentNullException("Header cannot be null");
            }

            string key = header.Key;

            headers[key] = header;
        }

        public bool ContainsKey(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null");
            }

            return this.headers.ContainsKey(key);           
        }

        public HttpHeader GetHeader(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null");
            }
            if (!this.ContainsKey(key))
            {
                throw new InvalidOperationException("The header with given key is not present");
            }
            return headers[key];
        }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, this.headers.Values);
        }
    }
}
