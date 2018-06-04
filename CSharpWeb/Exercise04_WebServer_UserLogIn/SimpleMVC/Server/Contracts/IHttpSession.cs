using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMVC.Server.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        bool IsLoggedIn();

        bool ContainsKey(string key);

        void ChangeState(bool loggedIn);        
    }
}
