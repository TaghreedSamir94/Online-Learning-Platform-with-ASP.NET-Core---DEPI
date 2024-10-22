

namespace SkillUP.DataAccessLayer.Entities.Users
{
	public class Instructor : GeneralUser
	{
		public string Education { get; set; }

		public string Description { get; set; }
		public ICollection<Course> Courses { get; set; }
	}
}
