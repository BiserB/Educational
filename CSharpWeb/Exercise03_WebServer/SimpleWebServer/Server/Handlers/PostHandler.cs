using System;
using SimpleWebServer.Server.HTTP.Contracts;

namespace SimpleWebServer.Server.Handlers
{
    public class PostHandler : RequestHandler
    {
        public PostHandler(Func<IHttpRequest, IHttpResponse> handlerFunc)
                : base(handlerFunc)
        {
        }
    }
}