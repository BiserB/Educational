namespace MyTube.App.Controllers
{
    using SimpleMvc.Framework.Controllers;
    using System.Text;

    public class BaseController : Controller
    {
        public override void OnAuthentication()
        {
            this.Model["message"] = "";

            if (this.User.IsAuthenticated)
            {
                this.Model["onGuest"] = "none";
                this.Model["onUser"] = "block";
            }
            else
            {
                this.Model["onGuest"] = "block";
                this.Model["onUser"] = "none";
            }
        }

        protected string GetErrors()
        {
            StringBuilder message = new StringBuilder();

            var errors = this.ParameterValidator.ModelErrors;

            foreach (var errorGroup in errors)
            {
                foreach (string error in errorGroup.Value)
                {
                    message.AppendLine($"<p>Error for {errorGroup.Key}: {error}</p>");
                }
            }

            return message.ToString();
        }
    }
}