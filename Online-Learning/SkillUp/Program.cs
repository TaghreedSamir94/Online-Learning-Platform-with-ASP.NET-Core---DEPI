using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillUp.BussinessLayer;
using SkillUp.BussinessLayer.Services;
using SkillUp.DataAccessLayer;
using SkillUp.DataAccessLayer;
using SkillUp.DataAccessLayer.Entities;
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
            // Register repositories
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
            // Register  services
            builder.Services.AddScoped<ICoursesService, CoursesService>();
            builder.Services.AddScoped<IUserService, UserService>();


            // Register DB
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);
                ;
            }
            );

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)//cookies
             .AddCookie(options =>
             {
                 options.ExpireTimeSpan = TimeSpan.FromDays(30);//allow to time of log in 
                 options.LoginPath = "Account/SignIn";
             });

            builder.Services.AddIdentity<User, IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDbContext>()// stores meaning repository
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
            // fill httpContext .user with its value
            app.UseAuthentication(); // who are you 
            app.UseAuthorization();  //allow to do samething 



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
           

