using SoftUni.Data;

namespace SoftUni.Services
{
    public abstract class BaseService
    {
        protected readonly SoftUniDbContext db;

        protected BaseService(SoftUniDbContext db)
        {
            this.db = db;
        }
    }
}