
namespace KittenWeb.App.Controllers
{
    using KittenWeb.App.Utils;
    using SimpleMvc.Framework.Controllers;
    using System.IO;
    using System.Text;

    public class BaseController : Controller
    {
        public override void OnAuthentication()
        {
            this.Model["message"] = "";

            if (this.User.IsAuthenticated)
            {
                //this.Model["onGuest"] = "none";
                //this.Model["onUser"] = "block";
                this.Model["topNav"] = File.ReadAllText(Paths.PartialViewsPath + "TopNavOnUser.html");
            }
            else
            {
                //this.Model["onGuest"] = "block";
                //this.Model["onUser"] = "none";
                this.Model["topNav"] = File.ReadAllText(Paths.PartialViewsPath + "TopNavOnGuest.html");
            }
        }

        protected string GetErrors()
        {
            StringBuilder message = new StringBuilder();

            var errors = this.ParameterValidator.ModelErrors;

            string s = @"<i class=""fa fa - exclamation - circle""></i>";

            foreach (var errorGroup in errors)
            {
                foreach (string error in errorGroup.Value)
                {
                    message.AppendLine($"<p>{s} Error for {errorGroup.Key}: {error}</p>");
                }
            }

            return message.ToString();
        }
    }
}
