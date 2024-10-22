using SkillUP.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs
{
    public class CourseDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }

        public int TotalHours { get; set; }
        public string promotionVideoUrl { get; set; }

        public string InstructorId { get; set; }

        public string InstructorName { get; set; }

        public string InstructorEducation { get; set; }
        public string InstructorDescription { get; set; }
        public bool IsEnrolled { get; set; }

        public static CourseDetailsDTO MapFromEntity(Course course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));

            return new CourseDetailsDTO
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                ImgUrl = course.ImgUrl,
                TotalHours = course.TotalHours,
                promotionVideoUrl = course.promotionVideoUrl,
                InstructorId = course.InstructorId,
                InstructorName = course.Instructor?.FullName,
                InstructorEducation = course.Instructor?.Education,
                InstructorDescription = course.Instructor?.Description
            };
        }
    }
}
