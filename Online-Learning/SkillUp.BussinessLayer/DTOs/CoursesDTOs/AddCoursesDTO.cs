using SkillUp.DataAccessLayer.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SkillUp.BussinessLayer.DTOs.CoursesDTOs
{
    public class AddCoursesDTO
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

		[Required(ErrorMessage = "Image is required")]
		[DisplayName("Promotion Video")]
		public string PromotionalVideoUrl { get; set; }

    }

    public static class AddcoursesDtoExtensions  //convert DTO into an entity model
	{
        public static Courses ToCourses(this AddCoursesDTO dto)
        {
            return new Courses
            {
                Title = dto.Title,
                Description = dto.Description,
                InstructorName = dto.InstructorName,
                Price = dto.Price,
                TotalHours = dto.TotalHours,
                ImgUrl = dto.ImgUrl,
                PromotionalVideoUrl = dto.PromotionalVideoUrl
            };
        }
    }
}
