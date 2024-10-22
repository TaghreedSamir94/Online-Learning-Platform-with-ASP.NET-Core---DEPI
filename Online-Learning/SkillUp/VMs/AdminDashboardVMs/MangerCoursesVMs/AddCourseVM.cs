using SkillUP.ActionRequests.AdminDashboardActionReq.MangerCoursesActionReq;
using SkillUP.ActionRequests.AdminDashboardActionReq.MangerUserActionReq;
using SkillUP.DataAccessLayer.Entities;
using SkillUP.VMs.AdminDashboardVMs.MangerUserVMs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerCoursesVMs
{
    public class AddCourseVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }

        public int TotalHours { get; set; }
        public string promotionVideoUrl { get; set; }

        public string InstructorId { get; set; }
		public IFormFile ImageFile { get; set; }

		public List<InstructorVM> Instructor { get; set; } //\ available instructors list



        public static AddCourseVM FromActionRequest(AddCourseActionReq request)
        {
            return new AddCourseVM
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
				ImageFile = request.ImageFile,
				TotalHours = request.TotalHours,
                promotionVideoUrl = request.promotionVideoUrl,
                InstructorId = request.InstructorId,
            };
        }
    }
}
