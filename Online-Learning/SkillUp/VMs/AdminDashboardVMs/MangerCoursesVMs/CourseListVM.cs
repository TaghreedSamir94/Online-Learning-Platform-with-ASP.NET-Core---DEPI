using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.MangeCoursesDTOs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerCoursesVMs
{
    public class CourseListVM
	{
        public int Id { get; set; }
        public string Title { get; set; }
       // public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public int TotalHours { get; set; }
        //public string promotionVideoUrl { get; set; }

        public string InstructorId { get; set; }

        public string InstructorName { get; set; }

        public static explicit operator CourseListVM(CoursesListDTO dto)
		{
			return new CourseListVM
			{
				Id = dto.Id,
				Title = dto.Title,
				Price = dto.Price,
				ImgUrl = dto.ImgUrl,
				TotalHours = dto.TotalHours,
				InstructorId = dto.InstructorId,
				InstructorName = dto.InstructorName
			};
		}

	}
}
