using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.DTOs.CoursesDTOs
{
	public class HomeCoursesDTO
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

        [DisplayName("Image")]
        public string ImgUrl { get; set; }
	}
}
