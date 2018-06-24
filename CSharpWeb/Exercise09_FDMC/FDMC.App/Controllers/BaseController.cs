
namespace FDMC.App.Controllers
{
    using FDMC.App.Utils;
    using SimpleMVC.Framework.Controllers;

    public abstract class BaseController : Controller
    {  
        protected void SetupLayoutHtml()
        {
            if (this.User.IsAuthenticated)
            {
                this.Model["Login"] = "";
                this.Model["Register"] = "";
                this.Model["Logout"] = PartialViews.LogoutButton;
                this.Model["AllKitten"] = PartialViews.AllKittenButton;
                this.Model["AddKitten"] = PartialViews.AddKittenButton;
            }
            else
            {
                this.Model["Login"] = PartialViews.LoginButton;
                this.Model["Register"] = PartialViews.RegisterButton;
                this.Model["Logout"] = "";
                this.Model["AllKitten"] = "";
                this.Model["AddKitten"] = "";
            }
        }
    }
}
