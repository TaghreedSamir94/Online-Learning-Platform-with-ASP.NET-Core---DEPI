using SkillUP.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs
{
    public class NewCoursesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public int TotalHours { get; set; }
        public string promotionVideoUrl { get; set; }
        public string InstructorName { get; set; }

        public string InstructorId { get; set; }


        public static NewCoursesDTO FromEntity(Course course)
        {
            return new NewCoursesDTO
            {
                Id = course.Id,
                Title = course.Title,
                Price = course.Price,
                TotalHours = course.TotalHours,
                promotionVideoUrl = course.promotionVideoUrl,
                ImgUrl = course.ImgUrl ?? "/Images/Courses/default-course.png",
                InstructorName = course.Instructor?.FullName
            };
        }
    }
}
