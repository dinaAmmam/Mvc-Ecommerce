using Microsoft.AspNetCore.Identity;
using Repoteq_task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.BearerToken;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Repoteq_task.Repository;


namespace Repoteq_task
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            //identity service line
            //builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<TaskContext>()/*.AddDefaultTokenProviders()*/;
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IOrderRepo, OrderRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
