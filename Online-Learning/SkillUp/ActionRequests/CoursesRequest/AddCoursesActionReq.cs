using SkillUp.BussinessLayer.DTOs.CoursesDTOs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.CoursesRequest
{
    public class AddCoursesActionReq
    {

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
		public IFormFile ImageFile { get; set; }

		public AddCoursesDTO ToDto()
        {
            return new AddCoursesDTO
            {
                Title = Title,
                Description = Description,
                InstructorName = InstructorName,
                Price = Price,
                TotalHours = TotalHours,
                //ImgUrl = ImgUrl,
            };
        }

    }
}
