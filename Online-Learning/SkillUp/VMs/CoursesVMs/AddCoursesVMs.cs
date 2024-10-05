using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.VMs.CoursesVMs
{
    public class AddCoursesVMs
    {
        public int ID { get; set; }

		[Required(ErrorMessage = "Title is required")]
		[StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
		public string Title { get; set; }

		[StringLength(3000, ErrorMessage = "Description cannot exceed 3000 characters")]
		public string Description { get; set; }


		[Required(ErrorMessage = "Instructor Name is required")]
		[DisplayName("Instructor Name")]
		public string InstructorName { get; set; }

		[Required(ErrorMessage = "Price is required")]
		[Range(1, 4000, ErrorMessage = "Price must be between 1 and 4000")]
		public float Price { get; set; }

		[Required(ErrorMessage = "Total Hours is required")]
		[DisplayName("Total Hours")]
		[Range(1, 200, ErrorMessage = "Total hours must be between 1 and 200")]
		public float TotalHours { get; set; }

		[Required(ErrorMessage = "Image is required")]
		[DisplayName("Image")]
        public string ImgUrl { get; set; }

		public IFormFile ImageFile { get; set; }


	}
}
