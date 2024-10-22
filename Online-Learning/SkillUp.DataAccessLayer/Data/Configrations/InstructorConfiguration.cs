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
	public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
	{
		public void Configure(EntityTypeBuilder<Instructor> builder)
		{
			builder.Property(i => i.Education)
				   .IsRequired()
				   .HasMaxLength(200);

			builder.Property(i => i.Description)
				   .IsRequired()
				   .HasMaxLength(20000);
		}
	}

}
