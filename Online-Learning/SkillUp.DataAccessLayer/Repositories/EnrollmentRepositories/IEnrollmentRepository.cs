using SkillUP.DataAccessLayer.Entities;
using SkillUP.DataAccessLayer.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.DataAccessLayer.Repositories.EnrollmentRepositories
{
    public interface IEnrollmentRepository : IGenericRepository<Enrollment>
    {
        Task<List<Enrollment>> GetByStudentIdAsync(string studentId);
        Task<bool> IsStudentEnrolledAsync(string studentId, int courseId);
    }
}
