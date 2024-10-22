using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs;

namespace SkillUP.ActionRequests.AdminDashboardActionReq.MangerUserActionReq
{
    public class AddUserActionReq
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string? Education { get; set; }
        public string? Description { get; set; }



        public static explicit operator AddUserDTO(AddUserActionReq request)
        {
            return new AddUserDTO
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
