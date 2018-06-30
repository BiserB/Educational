
namespace KittenWeb.App.Controllers
{
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class HomeController: BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Welcome();
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Index();
            }

            this.Model["username"] = User.Name;

            return this.View();
        }
    }
}
