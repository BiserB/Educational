using HTTPServer.Server.Enums;
using HTTPServer.Server.Http.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace HTTPServer.Server.Http.Response
{
    public class FileResponse : IHttpResponse
    {
        private string statusCodeMessage => this.StatusCode.ToString();

        public FileResponse(HttpStatusCode statusCode, byte[] content, string contentType)
        {
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.StatusCode = statusCode;
            this.Headers.Add("Content-Type", contentType);
            this.Headers.Add("Content-Length", content.Length.ToString());
            this.Content = content;
        }

        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }

        public HttpStatusCode StatusCode { get; protected set; }

        public byte[] Content { get; set; }

        public override string ToString()
        {
            var response = new StringBuilder();

            var statusCodeNumber = (int)this.StatusCode;

            response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.statusCodeMessage}");

            response.AppendLine(this.Headers.ToString());

            return response.ToString();
        }
    }
}
