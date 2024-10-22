using SkillUP.ActionRequests.AdminDashboardActionReq.MangerUserActionReq;
using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerUserVMs
{

    public class EditUserVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        // Instructor-specific fields
        public string Education { get; set; }
        public string Description { get; set; }

        // Mapping function
        public static EditUserVM FromDTO(EditUserDTO dto)
        {
            return new EditUserVM
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Email = dto.Email,
                Role = dto.Role,
                Education = dto.Education,
                Description = dto.Description
            };
        }

		public static EditUserDTO ToDTO(EditUserVM vm)
		{
			return new EditUserDTO
			{
                Id = vm.Id,
				FullName = vm.FullName,
				Email = vm.Email,
				Role = vm.Role,
                Education = vm.Education,
                Description = vm.Description
			
			};
		}
		public static EditUserVM FromDTO(UserDetailsDTO dto)
		{
			return new EditUserVM
			{
				FullName = dto.FullName,
				Email = dto.Email,
				Role = dto.Role,
				Education = dto.Education,
				Description = dto.Description
			};
		}

		public static EditUserVM FromActionRequest(EditUserActionReq request)
        {
            return new EditUserVM
            {
                //Id = request.Id,
                FullName = request.FullName,
                Email = request.Email,
                Role = request.Role,
                Education = request.Education,
                Description = request.Description
            };
        }

        public static explicit operator EditUserDTO(EditUserVM vm)
        {
            return new EditUserDTO
            {
                Id = vm.Id,
                FullName = vm.FullName,
                Email = vm.Email,
                Role = vm.Role,
                Education = vm.Education,
                Description = vm.Description
            };
        }

    }

}
