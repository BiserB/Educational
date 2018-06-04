using SimpleMVC.Server.Enums;

namespace SimpleMVC.Server.HTTP.Response
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}