using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkillUP.ActionRequests.AdminDashboardActionReq.MangerCoursesActionReq;
using SkillUP.BusinessLayer.DTOs.AccountDTOs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerCoursesVMs
{
    public class EditCourseVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int TotalHours { get; set; }
		public string ImgUrl { get; set; }
		public IFormFile ImageFile { get; set; }
        public string promotionVideoUrl { get; set; }
        public string InstructorId { get; set; }
        public List<SelectListItem> Instructors { get; set; }

     
        public static EditCourseVM FromCourseDetails(CourseDetailsVM courseDetails, List<InstructorDTO> instructorDtos)
        {
            return new EditCourseVM
            {
                Id = courseDetails.Id,
                Title = courseDetails.Title,
                Description = courseDetails.Description,
                Price = courseDetails.Price,
                TotalHours = courseDetails.TotalHours,
                promotionVideoUrl = courseDetails.promotionVideoUrl,
                InstructorId = courseDetails.InstructorId,
                ImgUrl = courseDetails.ImgUrl,
                Instructors = instructorDtos.Select(i => new SelectListItem
                {
                    Value = i.Id,
                    Text = i.FullName
                }).ToList()
            };
        }

        public static EditCourseVM FromActionRequest(EditCourseActionReq request)
        {
            return new EditCourseVM
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
				//ImageFile = request.ImageFile,
                TotalHours = request.TotalHours,
                promotionVideoUrl = request.promotionVideoUrl,
                InstructorId = request.InstructorId,
            
            };
        }

    }
}
