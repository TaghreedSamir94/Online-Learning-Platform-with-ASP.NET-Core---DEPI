using SkillUp.BussinessLayer.DTOs.CoursesDTOs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.VMs.CoursesVMs
{
	public class HomeCoursesVMs
	{
		public int ID { get; set; }

		[Required]
		public string Title { get; set; }

        public string Description { get; set; }

		[Required]
        [DisplayName("Instructor Name")]
        public string InstructorName { get; set; }

		[Required]
        [Range(1, 4000)]
        public float Price { get; set; }

		[Required]
        [DisplayName("Total Hours")]
        public float TotalHours { get; set; }
        
        [Required]
        [DisplayName("Image")]
        public string ImgUrl { get; set; }
        public IFormFile ImageFile { get; set; }

        public static explicit operator HomeCoursesVMs(HomeCoursesDTO dto)
        {
            return new HomeCoursesVMs
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description,
                InstructorName = dto.InstructorName,
                Price = dto.Price,
                TotalHours = dto.TotalHours,
                ImgUrl = dto.ImgUrl,
            };
        }
    }
}
