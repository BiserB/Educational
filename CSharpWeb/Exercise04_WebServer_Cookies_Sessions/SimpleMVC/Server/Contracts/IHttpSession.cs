using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMVC.Server.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        object GetParameter(string key);

        T Get<T>(string key);

        bool Contains(string key);

        void Add(string key, object value);

        void Clear();
    }
}
