using SimpleMVC.Server.Enums;

namespace SimpleMVC.Server.HTTP.Response
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
                : base()
        {
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader("Location", redirectUrl);
        }
    }
}