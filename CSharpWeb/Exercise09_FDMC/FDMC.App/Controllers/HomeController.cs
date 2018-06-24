
namespace FDMC.App.Controllers
{
    using SimpleMVC.Framework.Attributes.Methods;
    using SimpleMVC.Framework.Controllers;
    using SimpleMVC.Framework.Interfaces;

    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            this.SetupLayoutHtml();

            return this.View();
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            this.SetupLayoutHtml();

            this.Model["username"] = this.User.Name;

            return View();
        }

    }
}
