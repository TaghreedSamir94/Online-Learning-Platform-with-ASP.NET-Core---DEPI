using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkillUP.DataAccessLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.DataAccessLayer.Data.Configrations
{
	public class UserConfiguration : IEntityTypeConfiguration<GeneralUser>
	{
		public void Configure(EntityTypeBuilder<GeneralUser> builder)
		{
			// Configure TPT inheritance for the GeneralUser entity
			builder.HasDiscriminator<string>("UserType")
				   .HasValue<Student>("Student")
				   .HasValue<Instructor>("Instructor")
				   .HasValue<Admin>("Admin");

			builder.Property(u => u.Gender)
				   .HasConversion<string>(); // Store gender enum as string

			builder.Property(u => u.FullName)
				   .IsRequired()
				   .HasMaxLength(100); // Adjust length as needed

			// Additional configurations for Identity properties if needed
			builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
			builder.Property(u => u.NormalizedEmail).HasMaxLength(256);
			builder.Property(u => u.UserName).IsRequired().HasMaxLength(256);
			builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
		}
	}

}
