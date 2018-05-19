using Exercise03_WebServer.Server.Handlers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Exercise03_WebServer.Server.HTTP.Contracts;

namespace Exercise03_WebServer.Server.Handlers
{
    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> handlerFunc; 

        public RequestHandler(Func<IHttpRequest, IHttpResponse> handlerFunc)
        {
            this.handlerFunc = handlerFunc;
        }
        public IHttpResponse Handle(IHttpContext httpContext)
        {
            var response = this.handlerFunc(httpContext.Request);

            response.AddHeader("Content-Type", "text/html");

            return response;
        }
    }
}
