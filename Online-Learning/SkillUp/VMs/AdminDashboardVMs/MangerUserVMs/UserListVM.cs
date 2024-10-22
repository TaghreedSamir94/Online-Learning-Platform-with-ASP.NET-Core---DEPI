using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerUserVMs
{
    public class UserListVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Education { get; set; }
        public string Description { get; set; }

        // Explicit conversion from UserListDTO to UserListVM
        public static explicit operator UserListVM(UserListDTO dto)
        {
            return new UserListVM
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Email = dto.Email,
                Role = dto.Role,
                Education = dto.Education,
                Description = dto.Description
            };
        }


    }

}
