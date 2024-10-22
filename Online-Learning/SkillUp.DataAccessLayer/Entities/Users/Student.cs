
namespace SkillUP.DataAccessLayer.Entities.Users
{
	public class Student : GeneralUser
	{
		public ICollection<Enrollment> Enrollments { get; set; }
	}
}
