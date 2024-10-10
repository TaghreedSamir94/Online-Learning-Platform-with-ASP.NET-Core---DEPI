﻿using SkillUp.BussinessLayer.DTOs.CoursesDTOs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.CoursesRequest
{
	public class EditCoursesActionReq
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

        public IFormFile ImageFile { get; set; }

		[Required(ErrorMessage = "Image is required")]
		[DisplayName("Promotion Video")]
		public string PromotionalVideoUrl { get; set; }



        public static explicit operator EditCoursesDTO(EditCoursesActionReq actionReq)
		{
			return new EditCoursesDTO
			{
				ID = actionReq.ID,
				Title = actionReq.Title,
				Description = actionReq.Description,
				InstructorName = actionReq.InstructorName,
				Price = actionReq.Price,
				TotalHours = actionReq.TotalHours,
				//ImgUrl = actionReq.ImgUrl,
				PromotionalVideoUrl = actionReq.PromotionalVideoUrl,

			};
		}
	}
}

