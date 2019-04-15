using AutoMapper;

using SoftUni.Common;
using SoftUni.Models;
using SoftUni.Models.Dtos;

namespace SoftUni.App.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, UserInfoModel>();
            this.CreateMap<User, UserDetailsModel>();

            this.CreateMap<UserDto, User>();
            this.CreateMap<LectureDto, Lecture>();

            this.CreateMap<ResourceDto, Resource>();
            this.CreateMap<InstanceDto, CourseInstance>();

            this.CreateMap<CourseInstance, InstanceViewModel>();
            this.CreateMap<InstanceBindingModel, CourseInstance>();

            this.CreateMap<CourseInstance, InstanceBindingModel>();
            this.CreateMap<CourseInstance, EditInstanceBindingModel>();

            this.CreateMap<LectureBindingModel, Lecture>();
            this.CreateMap<Lecture, LectureBindingModel>();

            this.CreateMap<EditLectureBindingModel, Lecture>();
            this.CreateMap<Lecture, EditLectureBindingModel>();

            this.CreateMap<ResourceBindingModel, Resource>();
            this.CreateMap<Resource, ResourceBindingModel>();
        }
    }
}