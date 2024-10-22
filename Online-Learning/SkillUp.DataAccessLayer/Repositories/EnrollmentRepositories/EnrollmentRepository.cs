using Microsoft.EntityFrameworkCore;
using SkillUP.DataAccessLayer.Data;
using SkillUP.DataAccessLayer.Entities;
using SkillUP.DataAccessLayer.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.DataAccessLayer.Repositories.EnrollmentRepositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment> ,IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<Enrollment>> GetByStudentIdAsync(string studentId)
        {
            return await _context.Enrollments.Where(e => e.StudentId == studentId)
                                             .Include(e => e.Course).ToListAsync();
        }

        public async Task<bool> IsStudentEnrolledAsync(string studentId, int courseId)
        {
            return await _context.Enrollments.AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        }

    }
}
