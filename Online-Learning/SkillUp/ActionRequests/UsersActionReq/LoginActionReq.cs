using SkillUP.BusinessLayer.DTOs.AccountDTOs;
using SkillUP.VMs.AccountVMs;

namespace SkillUP.ActionRequests.UsersActionReq
{
	public class LoginActionReq
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }

		public static explicit operator LoginDTO(LoginActionReq request)
		{
			return new LoginDTO
			{
				Email = request.Email,
				Password = request.Password,
				RememberMe = request.RememberMe
			};
		}

		public LoginVM ToVM()
		{
			return new LoginVM
			{
				Email = this.Email,
				Password = this.Password,
				RememberMe = this.RememberMe
			};
		}
	}
}
