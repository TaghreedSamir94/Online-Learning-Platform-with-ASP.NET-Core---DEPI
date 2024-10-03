using Microsoft.EntityFrameworkCore;
using SkillUp.BussinessLayer.Services;
using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Register DB
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register repositories
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
// Register  services
builder.Services.AddScoped<ICoursesService, CoursesService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
