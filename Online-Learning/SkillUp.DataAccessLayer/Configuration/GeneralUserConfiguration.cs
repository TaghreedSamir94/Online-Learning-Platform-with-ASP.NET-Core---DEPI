using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillUp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Configuration
{
    public class GeneralUserConfiguration : IEntityTypeConfiguration<GeneralUser>
    {
        public void Configure(EntityTypeBuilder<GeneralUser> builder)
        {
            builder.UseTptMappingStrategy();
        }
    }
}
