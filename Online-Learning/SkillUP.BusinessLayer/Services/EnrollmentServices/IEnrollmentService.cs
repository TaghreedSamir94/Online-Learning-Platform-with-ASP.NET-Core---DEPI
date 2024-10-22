using SkillUP.BusinessLayer.DTOs.EnrollmentDTOs;
using SkillUP.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.Services.EnrollmentServices
{
    public interface IEnrollmentService
    {
       // Task EnrollStudentAsync(EnrollmentDTO enrollmentDto);
        Task<bool> EnrollInCourseAsync(string studentId, int courseId);
        Task<List<EnrollmentDTO>> GetEnrollmentsDTOSByStudentIdAsync(string studentId);
    }
}
