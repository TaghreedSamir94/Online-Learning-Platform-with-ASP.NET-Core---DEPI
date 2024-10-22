using SkillUP.ActionRequests.AdminDashboardActionReq.MangerUserActionReq;
using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerUserVMs
{
    public class DeleteUserVM
	{
		public string Email { get; set; }
		public string FullName { get; set; }

		public string Role { get; set; }


		public static DeleteUserVM FromUserDTO(UserDetailsDTO userDto) => new DeleteUserVM
		{
			Email = userDto.Email,
			FullName = userDto.FullName,
			Role = userDto.Role,
		};

		public static DeleteUserVM FromActionReq(DeleteUserActionReq req) => new DeleteUserVM
		{
			Email = req.Email
		};
	}
}
