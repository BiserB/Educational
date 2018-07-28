using BookLibrary.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.App.Controllers
{
    public class BaseController : Controller
    {
        protected BookLibraryDbContext db;

        public BaseController(BookLibraryDbContext db)
        {
            this.db = db;
        }
    }
}