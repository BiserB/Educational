using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SoftUni.Common.Settings;
using SoftUni.Data;
using SoftUni.Models;
using SoftUni.Models.Dtos;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SoftUni.App.Common
{
    public static class ApplicationBuilderAuthExtensions
    {
        private static readonly string AdminPass = "PASSword";
        private static readonly string UserPass = "pass";

        private static readonly IdentityRole[] roles =
        {
            new IdentityRole(RoleType.Student),
            new IdentityRole(RoleType.Trainer),
            new IdentityRole(RoleType.Admin),
            new IdentityRole(RoleType.SysAdmin),
        };

        public static async void InitialDbSeed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<SoftUniDbContext>();
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();

                dbContext.Database.Migrate();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }

                var sysadmin = await userManager.FindByNameAsync("sysadmin");

                if (sysadmin == null)
                {
                    var user = new User()
                    {
                        UserName = "sysadmin",
                        FullName = "SystemAdministrator",
                        Email = "sysadmin@mail.bg",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(user, AdminPass);

                    await userManager.AddToRoleAsync(user, roles[3].Name);
                }
            }
        }

        public static void SampleDataSeed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<SoftUniDbContext>();
                var mapper = scope.ServiceProvider.GetService<IMapper>();
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();

                if (dbContext.ResourceTypes.Any())
                {
                    return;
                }

                SeedResourceTypes(dbContext);

                SeedCourses(dbContext);

                SeedUsers(userManager, mapper);

                SeedInstances(dbContext, userManager, mapper);

                SeedLectures(dbContext, mapper);

                SeedResources(dbContext, mapper);
            }
        }

        private static void SeedResourceTypes(SoftUniDbContext dbContext)
        {
            var jsonResourceTypes = File.ReadAllText(@"wwwroot\SampleData\ResourceTypes.json");

            var resourceTypeDtos = JsonConvert.DeserializeObject<ResourceTypeDto[]>(jsonResourceTypes);

            var resourceTypes = resourceTypeDtos.Select(rt => new ResourceType() { Name = rt.Name }).ToList();

            dbContext.ResourceTypes.AddRange(resourceTypes);

            dbContext.SaveChanges();
        }

        private static void SeedCourses(SoftUniDbContext dbContext)
        {
            var jsonCourses = File.ReadAllText(@"wwwroot\SampleData\Cources.json");

            var courseDtos = JsonConvert.DeserializeObject<CourseDto[]>(jsonCourses);

            var courses = courseDtos.Select(cd => new Course() { Name = cd.Name }).ToList();

            dbContext.Courses.AddRange(courses);

            dbContext.SaveChanges();
        }

        private static void SeedUsers(UserManager<User> userManager, IMapper mapper)
        {
            var jsonUsers = File.ReadAllText(@"wwwroot\SampleData\Users.json");

            var userDtos = JsonConvert.DeserializeObject<UserDto[]>(jsonUsers);

            var users = mapper.Map<List<User>>(userDtos);

            foreach (var user in users)
            {
                userManager.CreateAsync(user, UserPass).Wait();

                userManager.AddToRoleAsync(user, roles[0].Name).Wait();
            }
        }

        private static void SeedInstances(SoftUniDbContext dbContext, UserManager<User> userManager, IMapper mapper)
        {
            var jsonInstances = File.ReadAllText(@"wwwroot\SampleData\Instances.json");

            var instanceDtos = JsonConvert.DeserializeObject<InstanceDto[]>(jsonInstances);

            var instances = mapper.Map<List<CourseInstance>>(instanceDtos);

            var trainer = userManager.FindByNameAsync("pesho").Result;

            userManager.AddToRoleAsync(trainer, RoleType.Trainer).Wait();

            foreach (var instance in instances)
            {
                instance.TrainerId = trainer.Id;
            }

            dbContext.CourseInstances.AddRange(instances);

            dbContext.SaveChanges();
        }

        private static void SeedLectures(SoftUniDbContext dbContext, IMapper mapper)
        {
            var jsonLectures = File.ReadAllText(@"wwwroot\SampleData\Lectures.json");

            var lectureDtos = JsonConvert.DeserializeObject<LectureDto[]>(jsonLectures);

            var lectures = mapper.Map<List<Lecture>>(lectureDtos);

            dbContext.Lectures.AddRange(lectures);

            dbContext.SaveChanges();
        }

        private static void SeedResources(SoftUniDbContext dbContext, IMapper mapper)
        {
            var jsonResources = File.ReadAllText(@"wwwroot\SampleData\Resources.json");

            var resourceDtos = JsonConvert.DeserializeObject<ResourceDto[]>(jsonResources);

            var resources = mapper.Map<List<Resource>>(resourceDtos);

            dbContext.AddRange(resources);

            dbContext.SaveChanges();
        }
    }
}