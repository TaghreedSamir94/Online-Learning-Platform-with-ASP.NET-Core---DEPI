using SkillUp.BussinessLayer.DTOs.CoursesDTOs;
using SkillUp.VMs.CoursesVMs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.CoursesRequest
{
	public class DeleteCoursesActionReq
	{
		public int ID { get; set; }
		
        public string ImgUrl { get; set; }

		


		public static explicit operator DeleteCoursesDTO(DeleteCoursesActionReq req)
		{
			return new DeleteCoursesDTO
			{
				ID = req.ID,
				ImgUrl = req.ImgUrl,
			
			};
		}
	}

}
