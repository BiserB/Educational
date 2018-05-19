using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.HTTP.Contracts
{
    public interface IHttpHeaderCollection
    {        
        void AddHeader(HttpHeader header);

        bool ContainsKey(string key);

        HttpHeader GetHeader(string key);
    }
}
