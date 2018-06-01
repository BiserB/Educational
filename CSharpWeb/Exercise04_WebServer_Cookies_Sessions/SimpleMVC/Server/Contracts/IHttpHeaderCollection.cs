using SimpleMVC.Server.HTTP;
using System.Collections.Generic;

namespace SimpleMVC.Server.Contracts
{
    public interface IHttpHeaderCollection
    {
        void AddHeader(HttpHeader header);

        bool ContainsKey(string key);

        ICollection<HttpHeader> GetHeaders(string key);
    }
}