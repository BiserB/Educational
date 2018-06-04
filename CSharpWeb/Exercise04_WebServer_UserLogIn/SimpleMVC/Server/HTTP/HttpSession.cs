using SimpleMVC.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMVC.Server.HTTP
{
    public class HttpSession : IHttpSession
    {
        private readonly Dictionary<string, bool> pair;

        public HttpSession(string id)
        {
            this.Id = id;
            this.pair = new Dictionary<string, bool>();
            pair[id] = false;
        }

        public string Id { get; }

        public void ChangeState(bool loggedIn)
        {
            pair[Id] = loggedIn;
        }

        public bool ContainsKey(string key)
        {
            return this.pair.ContainsKey(key);
        }

        public bool IsLoggedIn()
        {
            return pair[Id] == true;
        }

    }
}
