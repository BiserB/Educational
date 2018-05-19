using Exercise03_WebServer.Server.HTTP.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.HTTP
{
    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(string requestString)
        {
            if (requestString == null)
            {
                throw new ArgumentException("RequestString cannot be null");
            }

            this.request = new HttpRequest(requestString);
        }

        public IHttpRequest Request => this.request;
    }
}
