using SkillUp.BussinessLayer.DTOs.CoursesDTOs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.VMs.CoursesVMs
{
    public class CoursesListVMs
    {

        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("Instructor Name")]
        public string InstructorName { get; set; }

        [Required]
        [Range(1, 4000)]
        public float Price { get; set; }

        [Required]
        [DisplayName("Total Hours")]
        public float TotalHours { get; set; }

        [DisplayName("Image")]
        public string ImgUrl { get; set; }

		[Required(ErrorMessage = "Image is required")]
		[DisplayName("Promotion Video")]
		public string PromotionalVideoUrl { get; set; }



		// Static explicit operator to convert DTOs to VMs
		public static explicit operator CoursesListVMs(CoursesListDTO dto)
        {
            return new CoursesListVMs
            {
                ID = dto.ID,
                Title = dto.Title,
                InstructorName = dto.InstructorName,
                Price = dto.Price,
                TotalHours = dto.TotalHours,
                ImgUrl = dto.ImgUrl,
                PromotionalVideoUrl = dto.PromotionalVideoUrl,

            };
        }

    }
}
