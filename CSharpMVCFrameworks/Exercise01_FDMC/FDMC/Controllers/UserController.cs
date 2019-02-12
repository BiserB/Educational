using Microsoft.AspNetCore.Mvc;

namespace FDMC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}