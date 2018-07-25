using BookLibrary.Data;
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
    }
}