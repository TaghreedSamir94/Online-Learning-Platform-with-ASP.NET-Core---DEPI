using Azure.Core;
using SkillUP.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs
{
    public class AddCourseDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }

        public int TotalHours { get; set; }
        public string promotionVideoUrl { get; set; }

        public string InstructorId { get; set; }


		// Explicit operator to convert AddCourseDTO to Course
		public static explicit operator Course(AddCourseDTO dto)
        {
            return new Course
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                TotalHours = dto.TotalHours,
                promotionVideoUrl = dto.promotionVideoUrl,
                ImgUrl = dto.ImgUrl,
                InstructorId = dto.InstructorId
			};
        }
    }
}
