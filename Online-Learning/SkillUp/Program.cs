using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillUP.BusinessLayer.Services.AdminCourseMangerServices;
using SkillUP.BusinessLayer.Services.AdminUserMangerServices;
using SkillUP.BusinessLayer.Services.EnrollmentServices;
using SkillUP.BusinessLayer.Services.ProfileServices;
using SkillUP.BusinessLayer.Services.UserAccountServices;
using SkillUP.DataAccessLayer.Data;
using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.DataAccessLayer.Repositories.CourseRepositories;
using SkillUP.DataAccessLayer.Repositories.EnrollmentRepositories;
using SkillUP.DataAccessLayer.Repositories.GenericRepositories;
using SkillUP.DataAccessLayer.Repositories.UserRepositories;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//register DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();


// Register  services
builder.Services.AddScoped<ICourseServices, CourseServices>();
builder.Services.AddScoped<IUserMangerService, UserMangerService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IProfileService, ProfileService>();


builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddScoped<UserManager<GeneralUser>>();



//builder.Services.AddScoped<ICoursesService, CoursesService>();


builder.Services.AddIdentity<GeneralUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.SignIn.RequireConfirmedAccount = false;
})
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
	options.AddPolicy("RequireInstructorRole", policy => policy.RequireRole("Instructor"));
	options.AddPolicy("RequireStudentRole", policy => policy.RequireRole("Student"));
});



builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; 
});

var app = builder.Build();

// Seed Roles when the app starts
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	await SeedRolesAsync(services); // Call the role seeding function
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseSession();

app.UseStaticFiles();

app.UseRouting();

// Authentication & Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



// Role seeding function
async Task SeedRolesAsync(IServiceProvider serviceProvider)
{
	var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
	string[] roles = { "Admin", "Instructor", "Student" };

	foreach (var role in roles)
	{
		if (!await roleManager.RoleExistsAsync(role))
		{
			await roleManager.CreateAsync(new IdentityRole(role));
		}
	}
}