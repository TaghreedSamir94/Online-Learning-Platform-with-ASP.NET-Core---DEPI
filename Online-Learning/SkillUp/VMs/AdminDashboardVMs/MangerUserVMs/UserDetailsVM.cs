using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerUserVMs
{
    public class UserDetailsVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Education { get; set; }
        public string Description { get; set; }

		public static UserDetailsVM FromDTO(UserDetailsDTO dto)
		{
			return new UserDetailsVM
			{
				FullName = dto.FullName,
				Email = dto.Email,
				Role = dto.Role,
				Education = dto.Education,
				Description = dto.Description
			};
		}
	}
}
