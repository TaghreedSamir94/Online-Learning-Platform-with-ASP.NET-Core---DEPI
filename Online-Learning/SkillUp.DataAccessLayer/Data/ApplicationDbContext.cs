using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillUP.DataAccessLayer.Data.Configrations;
using SkillUP.DataAccessLayer.Entities;
using SkillUP.DataAccessLayer.Entities.Users;


namespace SkillUP.DataAccessLayer.Data
{
	public class ApplicationDbContext : IdentityDbContext<GeneralUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }

		public DbSet<Admin> Admins { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Apply configurations
			modelBuilder.ApplyConfiguration(new CourseConfiguration());
			modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new InstructorConfiguration());
		}
	}
}
