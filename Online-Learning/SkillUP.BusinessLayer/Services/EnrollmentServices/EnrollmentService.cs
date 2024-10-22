using Microsoft.EntityFrameworkCore;
using SkillUP.BusinessLayer.DTOs.EnrollmentDTOs;
using SkillUP.DataAccessLayer.Entities;
using SkillUP.DataAccessLayer.Repositories.CourseRepositories;
using SkillUP.DataAccessLayer.Repositories.EnrollmentRepositories;


namespace SkillUP.BusinessLayer.Services.EnrollmentServices
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollRepo;
        private readonly ICourseRepository _courseRepo;

        public EnrollmentService(IEnrollmentRepository enrollRepo , ICourseRepository courseRepo) 
        {
            _enrollRepo = enrollRepo;
            _courseRepo = courseRepo;
        }

        public async Task<bool> EnrollInCourseAsync(string studentId, int courseId)
        {
            var course = await _courseRepo.GetByIdAsync(courseId);
            if (course == null) return false;
            var isAlreadyEnrolled = await _enrollRepo.IsStudentEnrolledAsync(studentId, courseId);
            if (isAlreadyEnrolled)
            {
              return false;
            }
            var enrollment = new Enrollment
            {
                
                StudentId = studentId,
                CourseId = courseId,
                Progress = 0
            };

            await _enrollRepo.AddAsync(enrollment);
            await _enrollRepo.SaveAsync();
            return true;

        }

        public async Task<List<EnrollmentDTO>> GetEnrollmentsDTOSByStudentIdAsync(string studentId)
        {
            var enrollments = await _enrollRepo.GetByStudentIdAsync(studentId);
            return enrollments.Select(e => (EnrollmentDTO)e).ToList();
        }

       


    }
}
