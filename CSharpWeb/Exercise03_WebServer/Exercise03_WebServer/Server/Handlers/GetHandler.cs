using System;
using System.Collections.Generic;
using System.Text;
using Exercise03_WebServer.Server.HTTP.Contracts;

namespace Exercise03_WebServer.Server.Handlers
{
    public class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpRequest, IHttpResponse> handlerFunc) 
            : base(handlerFunc)
        {
        }
    }
}
