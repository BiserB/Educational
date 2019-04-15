using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUni.App.Common
{
    public static class ApplicationBuilderAuthExtensions
    {
        private static readonly string adminPass = "PASSword";
        private static readonly IdentityRole[] roles = 
            {
                new IdentityRole("Administrator"),
                new IdentityRole("Lecturer")
            };

        public static async void SeedDb(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();

            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }

                var admin = await userManager.FindByNameAsync("admin");

                if (admin == null)
                {
                    var user = new User()
                    {
                        UserName = "admin",
                        FullName = "Administrator",
                        Email = "admin@mail.bg",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(user, adminPass);

                    await userManager.AddToRoleAsync(user, roles[0].Name);
                }
            }
        }
    }
}
