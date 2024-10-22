using SkillUP.ActionRequests.AdminDashboardActionReq.MangerUserActionReq;
using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerUserVMs
{
    public class AddUserVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Instructor-specific fields
        public string Education { get; set; }
        public string Description { get; set; }



        public static explicit operator AddUserDTO(AddUserVM vm)
        {
            return new AddUserDTO
            {
                FullName = vm.FullName,
                Email = vm.Email,
                Password = vm.Password,
                Role = vm.Role,
                Education = vm.Education,
                Description = vm.Description
            };
        }

        public static AddUserVM FromActionRequest(AddUserActionReq request)
        {
            return new AddUserVM
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password,
                Role = request.Role,
                Education = request.Education,
                Description = request.Description
            };
        }
    }
}
