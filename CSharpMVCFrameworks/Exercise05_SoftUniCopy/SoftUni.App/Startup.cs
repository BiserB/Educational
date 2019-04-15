﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftUni.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using SoftUni.App.Areas.Identity.Services;
using SoftUni.Models;
using SoftUni.App.Common;
using AutoMapper;

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

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = $"/Identity/Account/Login";
            //    options.LogoutPath = $"/Identity/Account/Logout";
            //    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            //});

            services.AddDbContext<SoftUniDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<SoftUniDbContext>();

            services.AddAuthentication()
                    .AddFacebook(options =>
                    {                      
                        options.AppId = Configuration.GetSection("ExternalAuth:Facebook:AppId").Value;
                        options.AppSecret = Configuration.GetSection("ExternalAuth:Facebook:AppSecret").Value;
                    })
                    .AddGoogle(options =>
                    {
                        options.ClientId = Configuration.GetSection("ExternalAuth:Google:ClientId").Value;
                        options.ClientSecret = Configuration.GetSection("ExternalAuth:Google:ClientSecret").Value;
                    });

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

            services.AddAutoMapper();

            services.AddSingleton<IEmailSender, CustomEmailSender>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
                
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            if (env.IsDevelopment())
            {
                app.SeedDb();
            }

            app.UseMvc(routes =>
            {
                //routes.MapAreaRoute(
                //    name: "admin_area",
                //    areaName: "Admin",
                //    template: "Admin/{controller=Manager}/{action=Panel}/{id?}");

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Manager}/{action=Panel}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
