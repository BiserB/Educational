
using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Models;

namespace SimpleMVC.Application.Views
{
    public class UserDetailsView : IView
    {
        private readonly Model model;

        public UserDetailsView(Model model)
        {
            this.model = model;
        }

        public string View()
        {
            return $"<body>Hello, {model["name"]}!</body>";
        }
    }
}