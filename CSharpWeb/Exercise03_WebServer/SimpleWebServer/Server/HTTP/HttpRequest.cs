using SimpleWebServer.Server.HTTP.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleWebServer.Server.Enums;
using SimpleWebServer.Server.Exceptions;
using System.Net;

namespace SimpleWebServer.Server.HTTP
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, string>();
            this.HeaderCollection = new HttpHeaderCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();            

            this.ParseRequest(requestString);
        }
        
        public Dictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection HeaderCollection { get; private set; }

        public string Path { get; private set; }

        public Dictionary<string, string> QueryParameters { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameter(string key, string value)
        {
            if (key == null)
            {
                throw new ArgumentException("Key cannot be null");
            }

            this.UrlParameters[key] = value ?? throw new ArgumentException("Value cannot be null");
        }

        private void ParseRequest(string requestString)
        {
            string[] requestLines = requestString.Split(Environment.NewLine);

            string[] firstLine = requestLines[0]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (firstLine.Length != 3 || firstLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException("Invalid request line");
            }

            this.RequestMethod = this.ParseRequestMethod(firstLine[0].ToUpper());
            this.Url = firstLine[1];
            this.Path = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

            this.HeaderCollection = ParseHeaders(requestLines);
            this.ParseParameters();
            this.ParseFormData(requestLines[requestLines.Length - 1]);
        }
        
        private HttpHeaderCollection ParseHeaders(string[] requestLines)
        {
            int endIndex = Array.IndexOf(requestLines, String.Empty);
            HttpHeaderCollection httpHeaderCollection = new HttpHeaderCollection();

            for (int i = 1; i < endIndex; i++)
            {
                string[] headerArgs = requestLines[i].Split(new[] { ": "},StringSplitOptions.RemoveEmptyEntries);
                 
                HttpHeader httpHeader = new HttpHeader(headerArgs[0], headerArgs[1]);

                httpHeaderCollection.AddHeader(httpHeader);
            }

            if (!httpHeaderCollection.ContainsKey("Host"))
            {
                throw new BadRequestException("Invalid request");
            }

            return httpHeaderCollection;
        }

        private HttpRequestMethod ParseRequestMethod(string requestMethod)
        {

            if (!Enum.TryParse(requestMethod, out HttpRequestMethod method))
            {
                throw new BadRequestException("Invalid request method");
            }

            return method;
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }
            string query = this.Url.Split('?')[1];

            this.ParseQuery(query, this.UrlParameters);
        }

        private void ParseFormData(string formDataLine)
        {
            if (this.RequestMethod != HttpRequestMethod.POST)
            {
                return;
            }
            this.ParseQuery(formDataLine, this.FormData);
        }       

        private void ParseQuery(string query, IDictionary<string, string> dictionary)
        {
            
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split('&');

            foreach (var pair in queryPairs)
            {
                string[] splitted = pair.Split('=');
                if (splitted.Length != 2)
                {
                    return;
                }
                string key = WebUtility.UrlDecode(splitted[0]);
                string value = WebUtility.UrlDecode(splitted[1]);
                dictionary.Add(key, value);
            }
        }
                
    }
}
