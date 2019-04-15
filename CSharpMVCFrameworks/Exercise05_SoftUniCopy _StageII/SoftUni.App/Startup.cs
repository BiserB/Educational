using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftUni.App.Areas.Identity.Services;
using SoftUni.App.Common;
using SoftUni.Data;
using SoftUni.Models;
using SoftUni.Services.Trainer;
using SoftUni.Services.Trainer.Interfaces;

namespace SoftUni.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<SoftUniDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<SoftUniDbContext>();

            //services.AddAuthentication()
            //        .AddFacebook(options =>
            //        {
            //            options.AppId = Configuration.GetSection("ExternalAuth:Facebook:AppId").Value;
            //            options.AppSecret = Configuration.GetSection("ExternalAuth:Facebook:AppSecret").Value;
            //        })
            //        .AddGoogle(options =>
            //        {
            //            options.ClientId = Configuration.GetSection("ExternalAuth:Google:ClientId").Value;
            //            options.ClientSecret = Configuration.GetSection("ExternalAuth:Google:ClientSecret").Value;
            //        });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 4,
                    RequiredUniqueChars = 1,
                    RequireDigit = false,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = false,
                    RequireUppercase = false
                };

                //options.SignIn.RequireConfirmedEmail = true;
            });

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddAutoMapper();

            RegisterServiceLayer(services);

            services.AddSingleton<IEmailSender, CustomEmailSender>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.InitialDbSeed();
                app.SampleDataSeed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Manager}/{action=Panel}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void RegisterServiceLayer(IServiceCollection services)
        {
            services.AddScoped<ITrainerCoursesService, TrainerCoursesService>();

            services.AddScoped<ITrainerInstancesService, TrainerInstancesService>();
        }
    }
}