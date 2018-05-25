using SimpleWebServer.Application.Views;
using SimpleWebServer.Server.Enums;
using SimpleWebServer.Server.HTTP.Contracts;
using SimpleWebServer.Server.HTTP.Response;

namespace SimpleWebServer.Application.Controllers
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            var response = new ViewResponse(HttpStatusCode.OK, new HomeIndexView());

            return response;
        }
    }
}