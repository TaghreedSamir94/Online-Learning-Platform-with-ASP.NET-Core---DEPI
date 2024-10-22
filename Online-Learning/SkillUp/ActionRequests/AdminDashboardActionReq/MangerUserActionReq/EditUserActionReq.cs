using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs;

namespace SkillUP.ActionRequests.AdminDashboardActionReq.MangerUserActionReq
{
    public class EditUserActionReq
    {
        //public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public string Role { get; set; }
        public string? Education { get; set; }
        public string? Description { get; set; }



        public static explicit operator EditUserDTO(EditUserActionReq request)
        {
            return new EditUserDTO
            {
                FullName = request.FullName,
                Email = request.Email,
                Role = request.Role,
                Education = request.Education,
                Description = request.Description
            };
        }

        public static EditUserDTO FromActionRequest(EditUserActionReq request)
        {
            return new EditUserDTO
            {
                //Id = request.Id,
                FullName = request.FullName,
                Email = request.Email,
                Role = request.Role,
                Education = request.Education,
                Description = request.Description
            };
        }

    }
}
