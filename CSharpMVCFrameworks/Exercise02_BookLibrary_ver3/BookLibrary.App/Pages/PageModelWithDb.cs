using BookLibrary.Data;

namespace BookLibrary.App.Pages
{
    public class PageModelWithDb
    {
        protected readonly BookLibraryDbContext db;

        public PageModelWithDb(BookLibraryDbContext db)
        {
            this.db = db;
        }
    }
}