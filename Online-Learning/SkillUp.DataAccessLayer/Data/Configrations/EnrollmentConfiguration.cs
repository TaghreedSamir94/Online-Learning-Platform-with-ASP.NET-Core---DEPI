using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkillUP.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.DataAccessLayer.Data.Configrations
{
	public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
	{
		public void Configure(EntityTypeBuilder<Enrollment> builder)
		{
           
            builder.HasKey(e => new { e.CourseId, e.StudentId }); // Composite key

			// Many-to-Many: Student <-> Course through Enrollment
			builder.HasOne(e => e.Course)
				   .WithMany(c => c.Enrollments)
				   .HasForeignKey(e => e.CourseId);

			builder.HasOne(e => e.Student)
				   .WithMany(s => s.Enrollments)
				   .HasForeignKey(e => e.StudentId);

			// Add Progress tracking
			builder.Property(e => e.Progress)
				   .HasDefaultValue(0)
				   .IsRequired();
		}
	}

}
