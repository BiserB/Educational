using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.HTTP.Contracts
{
    public interface IHttpResponse
    {        
        void AddHeader(string key, string value);
    }
}
