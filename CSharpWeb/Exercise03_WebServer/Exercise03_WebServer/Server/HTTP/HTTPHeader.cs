using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.HTTP
{
    public class HttpHeader
    {
        private string key;
        private string value;

        public HttpHeader(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key
        {
            get { return this.key; }
            private set
            {
                this.key = value ?? throw new ArgumentNullException("Key cannot be null");
            }
        }

        public string Value
        {
            get { return this.value; }
            private set
            {
                this.value = value ?? throw new ArgumentNullException("Value cannot be null");
            }
        }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}
