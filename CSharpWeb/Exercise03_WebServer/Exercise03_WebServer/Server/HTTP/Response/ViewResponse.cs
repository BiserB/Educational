using Exercise03_WebServer.Server.Contracts;
using Exercise03_WebServer.Server.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Server.HTTP.Response
{
    public class ViewResponse : HttpResponse
    {
        private readonly IView view;

        public ViewResponse(HttpStatusCode httpStatusCode, IView view) 
                    : base()
        {
            this.StatusCode = httpStatusCode;
            this.view = view;
        }       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int codeOfStatus = (int)this.StatusCode;

            sb.AppendLine($"HTTP/1.1 {codeOfStatus} {this.StatusMessage}");
            sb.AppendLine(this.HeaderCollection.ToString());
            sb.AppendLine();

            if (codeOfStatus < 300 || codeOfStatus >= 400)
            {
                sb.AppendLine(this.view.View());
            }

            return sb.ToString();
        }
    }
}
