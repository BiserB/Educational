using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni.Services
{
    public abstract class ExtendedBaseService : BaseService
    {
        protected readonly IMapper mapper;
        protected readonly UserManager<User> userManager;

        public ExtendedBaseService(SoftUniDbContext db, IMapper mapper, UserManager<User> userManager)
                            : base(db)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }
    }
}