using Exercise03_WebServer.Server.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.HTTP.Response
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}
