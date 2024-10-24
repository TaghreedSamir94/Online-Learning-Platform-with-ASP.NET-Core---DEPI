using SkillUP.BusinessLayer.DTOs.AccountDTOs;
using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs;

namespace SkillUP.BusinessLayer.Services.AdminUserMangerServices
{
    public interface IUserMangerService
    {
        Task<List<UserListDTO>> GetAllUsersAsync();
        Task<UserDetailsDTO> GetUserByEmailAsync(string email);
        Task AddUserAsync(AddUserDTO dto);
        Task UpdateUserAsync(EditUserDTO dto);
        Task DeleteUserAsync(string email);
        // Task<EditUserDTO> GetUserByIdAsync(string id);

        Task<List<InstructorDTO>> GetAllInstructorsAsync();

        Task<List<UserListDTO>> SearchUsersByNameAsync(string name);
    }
}
