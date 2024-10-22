using SkillUP.BusinessLayer.DTOs.AccountDTOs;
using SkillUP.DataAccessLayer.Enums;
using SkillUP.VMs.AccountVMs;

namespace SkillUP.ActionRequests.UsersActionReq
{
	public class RegisteredInstructorActionReq
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public Gender Gender { get; set; }
		public string Education { get; set; }
		public string Description { get; set; }



		public static explicit operator RegisterInstructorDTO(RegisteredInstructorActionReq request)
		{
			return new RegisterInstructorDTO
			{
				FullName = request.FullName,
				Email = request.Email,
				Password = request.Password,
				Gender = request.Gender,
				ConfirmPassword = request.ConfirmPassword,
				Education = request.Education,
				Description = request.Description,
				Role = "Instructor",
			};
		}

		public RegisteredInstructorVM ToVM()
		{
			return new RegisteredInstructorVM
			{
				FullName = this.FullName,
				Email = this.Email,
				Gender = this.Gender,
				Password = this.Password,
				ConfirmPassword = this.ConfirmPassword,
				Education = this.Education,
				Description = this.Description,
				Role = "Instructor"
			};
		}
	}
}
