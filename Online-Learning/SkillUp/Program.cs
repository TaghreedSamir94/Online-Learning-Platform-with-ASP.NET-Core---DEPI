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

            builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
            // Register  services
            builder.Services.AddScoped<ICoursesService, CoursesService>();



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
                 options.LoginPath = "/Account/SignIn";
             });

            builder.Services.AddIdentity<GeneralUser, IdentityRole>(options =>
                              {
                                options.Password.RequireDigit= true;
                               })
                            .AddEntityFrameworkStores<ApplicationDbContext>()// stores meaning repository
                            .AddDefaultTokenProviders();

            //if user is not authenticated
            builder.Services
                .ConfigureApplicationCookie(options =>
                {
                    options.LoginPath="/Account/SignIn";
                    //the user is not authrized to accces some resourcs 
                    options.AccessDeniedPath ="/Account/AccessDenied";
                }
                );
              


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
        public static async Task SeedRolesAndAdminUser(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<GeneralUser>>();

            string[] roleNames = { "Admin", "Instructor", "Student" };

            // Create roles if they do not exist
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            // Create a default Admin user if it does not exist
            var adminEmail = "admin@skillup.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var newAdminUser = new GeneralUser
                {
                    UserName = "admin",
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var adminPassword = "Admin@123"; // Choose a strong password
                var createAdminUserResult = await userManager.CreateAsync(newAdminUser, adminPassword);

                if (createAdminUserResult.Succeeded)
                {
                    // Assign Admin role to the user
                    await userManager.AddToRoleAsync(newAdminUser, "Admin");
                }
            }
        }
    }
}
           

