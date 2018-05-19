using Exercise03_WebServer.Server.Routing.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.Contracts
{
    public interface IApplication
    {
        void Start(IAppRouteConfig appRouteConfig);
    }
}
