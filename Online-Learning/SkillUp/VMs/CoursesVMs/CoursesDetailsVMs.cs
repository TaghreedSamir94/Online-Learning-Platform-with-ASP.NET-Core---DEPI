using SkillUp.BussinessLayer.DTOs.CoursesDTOs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.VMs.CoursesVMs
{
    public class CoursesDetailsVMs
    {
  
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
     

        [Required]
        [DisplayName("Instructor Name")]
        public string InstructorName { get; set; }

        [Required]
        [Range(1, 4000, ErrorMessage = "Price should be between 1-4000")]
        public float Price { get; set; }

        [Required]
        [DisplayName("Total Hours")]
        public float TotalHours { get; set; }
		
		[Required]
        [DisplayName("Image")]
        public string ImgUrl { get; set; }

		public IFormFile ImageFile { get; set; }

		[Required(ErrorMessage = "Image is required")]
		[DisplayName("Promotion Video")]
		public string PromotionalVideoUrl { get; set; }


		public static explicit operator CoursesDetailsVMs(CoursesDetailsDTO dto)
		{
			return new CoursesDetailsVMs
			{
				ID = dto.ID,
				Title = dto.Title,
				Description = dto.Description,
				InstructorName = dto.InstructorName,
				Price = dto.Price,
				TotalHours = dto.TotalHours,
				ImgUrl = dto.ImgUrl,
				PromotionalVideoUrl = dto.PromotionalVideoUrl,
			};
		}

		public static explicit operator CoursesDetailsDTO(CoursesDetailsVMs vm)
		{
			return new CoursesDetailsDTO
			{
				ID = vm.ID,
				Title = vm.Title,
				Description = vm.Description,
				InstructorName = vm.InstructorName,
				Price = vm.Price,
				TotalHours = vm.TotalHours,
				ImgUrl = vm.ImgUrl,
				PromotionalVideoUrl=vm.PromotionalVideoUrl,
			};
		}

	}
}
