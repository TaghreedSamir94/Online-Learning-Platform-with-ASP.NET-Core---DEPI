using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerCoursesVMs
{
    public class CourseDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }

        public int TotalHours { get; set; }
        public string promotionVideoUrl { get; set; }

        public string InstructorId { get; set; }

        public string InstructorName { get; set; }

        public string InstructorEducation { get; set; }
        public string InstructorDescription { get; set; }
        public bool IsEnrolled { get; set; }

        public static CourseDetailsVM FromDto(CourseDetailsDTO dto)
        {
            return new CourseDetailsVM
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                ImgUrl = dto.ImgUrl,
                TotalHours = dto.TotalHours,
                promotionVideoUrl = dto.promotionVideoUrl,
                InstructorId = dto.InstructorId,
                InstructorName = dto.InstructorName,
                InstructorEducation = dto.InstructorEducation,
                InstructorDescription = dto.InstructorDescription,
                IsEnrolled = dto.IsEnrolled,
            };
        }

		public static explicit operator CourseDetailsVM(CourseDetailsDTO dto)
		{
			return new CourseDetailsVM
			{
				Id = dto.Id,
				Title = dto.Title,
				ImgUrl = dto.ImgUrl
			};
		}

		public static explicit operator DeleteCourseDTO(CourseDetailsVM detailsVM)
		{
			return new DeleteCourseDTO
			{
				Id = detailsVM.Id,
				Title = detailsVM.Title,
				ImgUrl = detailsVM.ImgUrl
			};
		}


	}
}
