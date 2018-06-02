using SimpleMVC.Server.Contracts;

namespace SimpleMVC.Application.Views
{
    public class HomeView : IView
    {
        public string View()
        {
            return "<body><h1>Welcome!</h1><p></p>" +
                "<a href=\"/register\">Register</a></body>";
        }
    }
}