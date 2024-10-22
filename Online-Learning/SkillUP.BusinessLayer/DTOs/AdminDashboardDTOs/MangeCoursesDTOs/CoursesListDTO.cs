using SkillUP.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs
{
    public class CoursesListDTO
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

        public static CoursesListDTO MapFromEntity(Course course)
        {
            return new CoursesListDTO
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                ImgUrl = course.ImgUrl,
                TotalHours = course.TotalHours,
                promotionVideoUrl = course.promotionVideoUrl,
                InstructorId = course.InstructorId,
                InstructorName = course.Instructor?.FullName ?? "Unknown Instructor"
            };
        }


    }
}
