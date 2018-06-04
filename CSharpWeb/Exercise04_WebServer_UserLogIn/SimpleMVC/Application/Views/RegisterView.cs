using SimpleMVC.Server.Contracts;

namespace SimpleMVC.Application.Views
{
    public class RegisterView : IView
    {
        public string View()
        {
            return "<body><form method=\"POST\"> " +
                    "   Name <em style=\"font-size:0.8em\">(Only letters,digits and underline)</em></br><p></p>" +
                    "   <input type=\"text\" name=\"name\" pattern=\"\\w+\"/></br><p></p>" +
                    "   <input type=\"submit\"/>" +
                    "</form></body>";
        }
    }
}