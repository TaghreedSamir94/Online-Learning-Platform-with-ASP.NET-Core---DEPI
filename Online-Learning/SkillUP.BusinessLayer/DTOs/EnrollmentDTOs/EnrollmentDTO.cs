using SkillUP.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.EnrollmentDTOs
{
    public class EnrollmentDTO
    {
       
        public int CourseId { get; set; }
        public string StudentId { get; set; }
        public double Progress { get; set; }
        //public string CourseTitle { get; set; }
         public Course CourseObj { get; set; }
        


        public static Enrollment ToEntity(EnrollmentDTO enrollmentDto)
        {
            return new Enrollment
            {
        
                StudentId = enrollmentDto.StudentId,
                CourseId = enrollmentDto.CourseId,
                Progress = enrollmentDto.Progress
            };
        }

        public static EnrollmentDTO FromEntity(Enrollment enrollment)
        {
            return new EnrollmentDTO
            {
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                Progress = enrollment.Progress
            };
        }

        // Explicit operator to convert from DTO to Entity
        public static explicit operator Enrollment(EnrollmentDTO dto)
        {
            return new Enrollment
            {
        
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                Progress = dto.Progress,
                Course = dto.CourseObj,
            };
        }

        public static explicit operator EnrollmentDTO(Enrollment enrollment)
        {
            return new EnrollmentDTO
            {

                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                Progress = enrollment.Progress,
                CourseObj = enrollment.Course,
 
            };
        }

    }
}
