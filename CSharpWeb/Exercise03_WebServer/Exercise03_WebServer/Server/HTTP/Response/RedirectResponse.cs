using Exercise03_WebServer.Server.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.HTTP.Response
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
