using SimpleWebServer.Application.Views;
using SimpleWebServer.Server;
using SimpleWebServer.Server.Enums;
using SimpleWebServer.Server.HTTP.Contracts;
using SimpleWebServer.Server.HTTP.Response;

namespace SimpleWebServer.Application.Controllers
{
    public class UserController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new RegisterView());
        }

        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public IHttpResponse Details(string name)
        {
            Model model = new Model { ["name"] = name };

            return new ViewResponse(HttpStatusCode.OK, new UserDetailsView(model));
        }
    }
}