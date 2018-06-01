using SimpleMVC.Server.Handlers;
using System.Collections.Generic;

namespace SimpleMVC.Server.Contracts
{
    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler RequestHandler { get; }
    }
}