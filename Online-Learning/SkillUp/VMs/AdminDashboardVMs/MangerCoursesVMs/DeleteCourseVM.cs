using Microsoft.AspNetCore.Mvc.Rendering;
using SkillUP.BusinessLayer.DTOs.AccountDTOs;
using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerCoursesVMs
{
    public class DeleteCourseVM
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
		//public string InstructorName { get; set; }
		public List<SelectListItem> Instructors { get; set; }

		public static DeleteCourseVM FromDto(CourseDetailsDTO detailsDTO, List<InstructorDTO> instructorDtos)
{
    return new DeleteCourseVM
    {
        Id = detailsDTO.Id,
        Title = detailsDTO.Title,
        ImgUrl = detailsDTO.ImgUrl,
        Price = detailsDTO.Price,
        TotalHours = detailsDTO.TotalHours,
        Description = detailsDTO.Description,
        promotionVideoUrl = detailsDTO.promotionVideoUrl,
        InstructorId = detailsDTO.InstructorId,

        // Populate instructors for the select field
        Instructors = instructorDtos.Select(i => new SelectListItem
        {
            Value = i.Id.ToString(),
            Text = i.FullName,
            Selected = i.Id == detailsDTO.InstructorId
        }).ToList()
    };
}


	}
}
