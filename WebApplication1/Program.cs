using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers.Filter;
using WebApplication1.Data;
using WebApplication1.repos;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ITIDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("con1")));

            builder.Services.AddScoped<IDeptRepo, DeptRepo>();
            builder.Services.AddScoped<IRepoCourse, CourseRepo>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<IRepoStudentCourse, StudentCourseRepo>();


            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AuthrizationFilter>();
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(a =>
            {
                a.LoginPath = "/Login/Login";
                a.AccessDeniedPath = "/Login/AccessError";

            });




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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
