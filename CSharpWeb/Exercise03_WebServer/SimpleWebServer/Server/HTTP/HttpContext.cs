using SimpleWebServer.Server.HTTP.Contracts;
using System;


namespace SimpleWebServer.Server.HTTP
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
