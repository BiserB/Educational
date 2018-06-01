using SimpleMVC.Application.Views;
using SimpleMVC.Server;
using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Enums;
using SimpleMVC.Server.HTTP.Response;
using SimpleMVC.Server.Models;

namespace SimpleMVC.Application.Controllers
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