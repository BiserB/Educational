using System;
using SimpleWebServer.Server.Handlers.Contracts;
using SimpleWebServer.Server.HTTP.Contracts;

namespace SimpleWebServer.Server.Handlers
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