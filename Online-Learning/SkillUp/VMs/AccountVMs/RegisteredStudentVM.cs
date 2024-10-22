using SkillUP.DataAccessLayer.Enums;

namespace SkillUP.VMs.AccountVMs
{
	public class RegisteredStudentVM
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public Gender Gender { get; set; }

		public string Role { get; set; }
	}
}
