using SkillUP.DataAccessLayer.Entities.Users;
namespace SkillUP.DataAccessLayer.Entities
{
	public class Course
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string ImgUrl { get; set; } = "defaultImage.jpg";

		public int TotalHours { get; set; }
		public string promotionVideoUrl { get; set; }

		public string InstructorId { get; set; }
		public Instructor Instructor { get; set; }
		public ICollection<Enrollment> Enrollments { get; set; }

	}
}
