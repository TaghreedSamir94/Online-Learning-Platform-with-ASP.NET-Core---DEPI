using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs
{
    public class DeleteCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }

        public int TotalHours { get; set; }
        public string promotionVideoUrl { get; set; }

        public string InstructorId { get; set; }
    }
}
