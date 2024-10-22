using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerCoursesVMs
{
    public class NewCoursesVM
	{
		
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string ImgUrl { get; set; }
		public int TotalHours { get; set; }
		public string InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string promotionVideoUrl { get; set; }




        public static explicit operator NewCoursesVM(NewCoursesDTO dto)
		{
			return new NewCoursesVM
			{
				Id = dto.Id,
				Title = dto.Title,
				Description = dto.Description,
				Price = dto.Price,
				TotalHours = dto.TotalHours,
				ImgUrl = dto.ImgUrl,
				promotionVideoUrl = dto.promotionVideoUrl,
                InstructorName = dto.InstructorName,
                InstructorId = dto.InstructorId,
			};
		}


	}
}
