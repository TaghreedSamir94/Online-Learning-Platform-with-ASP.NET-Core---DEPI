using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs;
using SkillUP.VMs.AdminDashboardVMs.MangerCoursesVMs;

namespace SkillUP.ActionRequests.AdminDashboardActionReq.MangerCoursesActionReq
{
    public class DeleteCourseActionReq
	{
		public int Id { get; set; }
		



		public static explicit operator CourseDetailsVM(DeleteCourseActionReq deleteRequest)
		{
			return new CourseDetailsVM
			{
				Id = deleteRequest.Id,
				
			};
		}

		public DeleteCourseDTO ToDto()
		{
			return new DeleteCourseDTO
			{
				Id = this.Id,
				

			};
		}
	}
}
