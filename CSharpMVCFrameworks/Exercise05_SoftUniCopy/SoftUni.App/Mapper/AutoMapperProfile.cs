using AutoMapper;
using SoftUni.App.Areas.Admin.Models.ViewModels;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUni.App.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, UserInfoModel>();
            this.CreateMap<User, UserDetailsModel>();
        }
    }
}
