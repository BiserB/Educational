using System;
using SimpleWebServer.Server.HTTP.Contracts;

namespace SimpleWebServer.Server.Handlers
{
    public class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpRequest, IHttpResponse> handlerFunc)
            : base(handlerFunc)
        {
        }
    }
}