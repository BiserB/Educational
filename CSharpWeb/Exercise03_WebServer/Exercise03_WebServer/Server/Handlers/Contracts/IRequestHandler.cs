using Exercise03_WebServer.Server.HTTP.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.Handlers.Contracts
{
    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext httpContext);
    }
}
