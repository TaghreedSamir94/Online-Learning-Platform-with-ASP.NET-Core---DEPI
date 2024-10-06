using Microsoft.EntityFrameworkCore;
using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Repositories.Enrollment
{
    public class EnrollmentRepository : GenericRepository<EnrollmentC>, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
