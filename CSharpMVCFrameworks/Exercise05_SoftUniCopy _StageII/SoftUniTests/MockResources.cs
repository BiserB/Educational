using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftUni.App.Mapper;
using SoftUni.Data;
using SoftUni.Models;
using System;

namespace SoftUniTests
{
    public static class MockResources
    {
        public static SoftUniDbContext GetEmptyTestDb()
        {
            var options = new DbContextOptionsBuilder<SoftUniDbContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;

            var db = new SoftUniDbContext(options);

            return db;
        }

        public static SoftUniDbContext GetTestDb()
        {
            var options = new DbContextOptionsBuilder<SoftUniDbContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;

            var db = new SoftUniDbContext(options);

            db.Courses.Add(new Course() { Id = 1, Name = "C# Fund" });
            db.Courses.Add(new Course() { Id = 2, Name = "Java Fund" });
            db.Courses.Add(new Course() { Id = 3, Name = "PHP" });
            db.CourseInstances.Add(new CourseInstance() { Id = 1, Name = "C# Fund 2016", CourseId = 1 });
            db.CourseInstances.Add(new CourseInstance() { Id = 2, Name = "C# Fund 2017", CourseId = 1 });
            db.CourseInstances.Add(new CourseInstance() { Id = 3, Name = "C# Fund 2018", CourseId = 1 });

            db.SaveChanges();

            return db;
        }

        public static IMapper GetTestMapper()
        {
            AutoMapper.Mapper.Initialize(opt => opt.AddProfile<AutoMapperProfile>());

            return AutoMapper.Mapper.Instance;
        }
    }
}