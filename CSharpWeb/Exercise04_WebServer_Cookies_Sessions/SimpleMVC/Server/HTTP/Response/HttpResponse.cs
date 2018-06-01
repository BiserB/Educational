using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Enums;
using System.Text;

namespace SimpleMVC.Server.HTTP.Response
{
    public abstract class HttpResponse : IHttpResponse
    {
        protected HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.CookieCollection = new HttpCookieCollection();
        }

        public IHttpHeaderCollection HeaderCollection { get; }

        public IHttpCookieCollection CookieCollection { get; }

        public HttpStatusCode StatusCode { get; protected set; }

        public string StatusMessage => this.StatusCode.ToString();

        public void AddHeader(string key, string redirectUrl)
        {
            HttpHeader httpHeader = new HttpHeader(key, redirectUrl);

            this.HeaderCollection.AddHeader(httpHeader);
        }

        public void AddCookie(HttpCookie cookie)
        {            
            this.CookieCollection.AddCookie(cookie);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int codeOfStatus = (int)this.StatusCode;

            sb.AppendLine($"HTTP/1.1 {codeOfStatus} {this.StatusMessage}");
            sb.AppendLine(this.HeaderCollection.ToString());
            sb.AppendLine();

            return sb.ToString();
        }
    }
}