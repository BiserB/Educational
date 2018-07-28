using BookLibrary.App.Auxiliary;
using BookLibrary.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLibrary.App.Pages
{
    public class PageModelWithDb : PageModel
    {
        protected readonly BookLibraryDbContext db;

        public PageModelWithDb(BookLibraryDbContext db)
        {
            this.db = db;
        }

        public bool IsLoggedIn()
        {
            string cookie = this.Request.Cookies[SessionKeys.UserKey];

            if (cookie != null)
            {
                var key = this.HttpContext.Session.GetString(cookie);

                if (key == SessionKeys.UserKey)
                {
                    ViewData["ButtonType"] = "Logout";

                    return true;
                }
            }

            return false;
        }
    }
}