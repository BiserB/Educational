using System;
using SimpleWebServer.Server.Enums;

namespace SimpleWebServer.Server.HTTP.Response
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
                : base()
        {
            if (redirectUrl == null)
            {
                throw new ArgumentNullException("Redirect Url is null");
            }
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader("Location", redirectUrl);
        }
    }
}