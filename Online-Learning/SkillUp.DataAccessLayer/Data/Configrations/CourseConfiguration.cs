using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillUP.DataAccessLayer.Entities;


namespace SkillUP.DataAccessLayer.Data.Configrations
{
	public class CourseConfiguration : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder) 
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
			builder.Property(c => c.ImgUrl).IsRequired().HasDefaultValue("/Images/Courses/default-course.png");
			builder.Property(c => c.promotionVideoUrl).IsRequired();
			builder.Property(c => c.Description)
				   .IsRequired()
				   .HasMaxLength(20000); 

			builder.Property(c => c.Price)
				   .HasPrecision(18, 2) // Decimal precision: max 18 dgt
				   .IsRequired(); 

			builder.Property(c => c.TotalHours)
				   .IsRequired(); 

			// One-to-Many: Instructor teaches many courses
			builder.HasOne(c => c.Instructor)
				   .WithMany(i => i.Courses)
				   .HasForeignKey(c => c.InstructorId)
				   .OnDelete(DeleteBehavior.Restrict);
		}


	}
}
	

