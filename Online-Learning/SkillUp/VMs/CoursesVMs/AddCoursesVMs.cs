using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.VMs.CoursesVMs
{
    public class AddCoursesVMs
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


	}
}
