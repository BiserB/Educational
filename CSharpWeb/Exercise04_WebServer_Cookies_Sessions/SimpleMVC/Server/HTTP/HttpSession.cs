using SimpleMVC.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMVC.Server.HTTP
{
    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> values;

        public HttpSession(string id)
        {
            this.Id = id;
            this.values = new Dictionary<string, object>();
        }

        public string Id { get; }

        public void Add(string key, object value)
        {
            this.values[key] = value;
        }

        public void Clear()
        {
            this.values.Clear();
        }

        public T Get<T>(string key)
            => (T)this.GetParameter(key);        

        public bool Contains(string key) => this.values.ContainsKey(key);

        public object GetParameter(string key)
        {
            if (!this.values.ContainsKey(key))
            {
                return null;
            }

            return values[key];
        }

    }
}
