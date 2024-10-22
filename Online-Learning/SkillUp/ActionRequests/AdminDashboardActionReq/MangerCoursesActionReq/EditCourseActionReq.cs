using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs;

namespace SkillUP.ActionRequests.AdminDashboardActionReq.MangerCoursesActionReq
{
    public class EditCourseActionReq
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


        public EditCourseDTO ToDto()
        {
            return new EditCourseDTO
            {
                Id = this.Id,
                Title = this.Title,
                Description = this.Description,
                Price = this.Price,
                TotalHours = this.TotalHours,
                //ImgUrl = this.ImgUrl,
                promotionVideoUrl = this.promotionVideoUrl,
                InstructorId = this.InstructorId

            };
        }

       
        
    }
}
