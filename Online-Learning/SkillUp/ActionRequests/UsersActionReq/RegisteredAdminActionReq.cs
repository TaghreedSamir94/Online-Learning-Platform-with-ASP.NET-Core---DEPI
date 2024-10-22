using SkillUP.BusinessLayer.DTOs.AccountDTOs;
using SkillUP.DataAccessLayer.Enums;
using SkillUP.VMs.AccountVMs;

namespace SkillUP.ActionRequests.UsersActionReq
{
	public class RegisteredAdminActionReq
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public Gender Gender { get; set; }

		public static explicit operator RegisterDTO(RegisteredAdminActionReq request)
		{
			return new RegisterDTO
			{
				FullName = request.FullName,
				Email = request.Email,
				Password = request.Password,
				ConfirmPassword = request.ConfirmPassword,
				Gender = request.Gender,
				Role = "Admin" 
			};
		}


		public RegisteredAdminVM ToVM()
		{
			return new RegisteredAdminVM
			{
				FullName = this.FullName,
				Email = this.Email,
				Gender = this.Gender,
				Password = this.Password,
				ConfirmPassword = this.ConfirmPassword,
				Role = "Admin" 
			};
		}
	}
}
