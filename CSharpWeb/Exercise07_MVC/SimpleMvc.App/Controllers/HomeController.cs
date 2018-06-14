namespace SimpleMvc.App.Controllers
{
    using SimpleMVC.Framework.Attributes.Methods;
    using SimpleMVC.Framework.Controllers;
    using SimpleMVC.Framework.Interfaces;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}