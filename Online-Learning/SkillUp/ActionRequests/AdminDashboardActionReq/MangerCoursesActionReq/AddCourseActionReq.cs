using Azure.Core;
using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs;
using SkillUP.VMs.AdminDashboardVMs.MangerCoursesVMs;

namespace SkillUP.ActionRequests.AdminDashboardActionReq.MangerCoursesActionReq
{
    public class AddCourseActionReq
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
       // public string ImgUrl { get; set; }

        public int TotalHours { get; set; }
        public string promotionVideoUrl { get; set; }

        public string InstructorId { get; set; }
        public IFormFile ImageFile { get; set; }


		public AddCourseDTO ToDto()
        {
            return new AddCourseDTO
            {
                Title = this.Title,
                Description = this.Description,
                Price = this.Price,
                TotalHours = this.TotalHours,
				promotionVideoUrl = this.promotionVideoUrl,
                InstructorId = this.InstructorId

			};
        }
    }
}
