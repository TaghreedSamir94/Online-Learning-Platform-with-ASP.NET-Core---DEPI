using Microsoft.AspNetCore.Identity;
using SkillUP.DataAccessLayer.Enums;


namespace SkillUP.DataAccessLayer.Entities.Users
{
	public class GeneralUser : IdentityUser
	{
		public string FullName { get; set; }
		public Gender Gender { get; set; }

		public string UserType { get; set; }
	}
}
