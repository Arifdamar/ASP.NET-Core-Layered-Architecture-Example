using System;
using Arif.ToDo.Business.DiContainer;
using Arif.ToDo.Business.ValidationRules.FluentValidation;
using Arif.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Arif.ToDo.DTO.DTOs.AppUserDTOs;
using Arif.ToDo.DTO.DTOs.ReportDTOs;
using Arif.ToDo.DTO.DTOs.TaskDTOs;
using Arif.ToDo.DTO.DTOs.UrgencyDTOs;
using Arif.ToDo.Entities.Concrete;
using Arif.ToDo.Web.CustomCollectionExtensions;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Arif.ToDo.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies();

            services.AddDbContext<TodoContext>();
            
            services.AddCustomIdentity();

            services.AddAutoMapper(typeof(Startup));

            services.AddCustomValidator();

            services
                .AddControllersWithViews()
                .AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            // ReSharper disable once AsyncConverter.AsyncWait
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller=Home}/{Action=Index}/{id?}");
            });
        }
    }
}
