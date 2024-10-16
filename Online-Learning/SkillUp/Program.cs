using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillUp.BussinessLayer.Services;
using SkillUp.BussinessLayer.Services.Users;
using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Entities.UserEntities;
using SkillUp.DataAccessLayer.Repositories;
using SkillUp.DataAccessLayer.Repositories.GenericRepositories;
using SkillUp.DataAccessLayer.Repositories.UserRepo;

namespace SkillUp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Register DB
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Register repositories
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>(); 
            // Register  services
            builder.Services.AddScoped<ICoursesService, CoursesService>();
            builder.Services.AddScoped<IUserService, UserService>();


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)//cookies
                        .AddCookie(options =>
                        {
                            options.ExpireTimeSpan = TimeSpan.FromDays(30);//allow to time of log in 
                            options.LoginPath = "/SignIn";
                        });


            builder.Services.AddIdentity<GeneralUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseHttpsRedirection();

            // Use authentication and authorization
            app.UseAuthentication(); 
            app.UseAuthorization();  



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
           

