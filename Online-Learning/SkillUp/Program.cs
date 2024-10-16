using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillUp.BussinessLayer.Services;
using SkillUp.BussinessLayer.Services.Enrollment;
using SkillUp.BussinessLayer.Services.Progress;
using SkillUp.BussinessLayer.Services.Users;
using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Repositories;
using SkillUp.DataAccessLayer.Repositories.Enrollment;
using SkillUp.DataAccessLayer.Repositories.GenericRepositories;
using SkillUp.DataAccessLayer.Repositories.Progress;
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
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            builder.Services.AddScoped<IProgressRepository, ProgressRepository>();
            // Register  services
            builder.Services.AddScoped<ICoursesService, CoursesService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
            builder.Services.AddScoped<IProgrssService, ProgressService>();


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)//cookies
                        .AddCookie(options =>
                        {
                            options.ExpireTimeSpan = TimeSpan.FromDays(30);//allow to time of log in 
                            options.LoginPath = "/SignIn";
                        });

            builder.Services.AddIdentity<User, Role>()
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
           

