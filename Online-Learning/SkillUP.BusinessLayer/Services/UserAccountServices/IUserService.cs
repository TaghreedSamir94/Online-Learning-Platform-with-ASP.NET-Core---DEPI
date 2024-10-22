using Microsoft.AspNetCore.Identity;
using SkillUP.BusinessLayer.DTOs.AccountDTOs;
using SkillUP.DataAccessLayer.Entities.Users;


namespace SkillUP.BusinessLayer.Services.UserAccountServices
{
	public interface IUserService
	{
		Task<IdentityResult> RegisterUserAsync(RegisterDTO registerDto);
		Task<IdentityResult> RegisterInstructorAsync(RegisterInstructorDTO registerinstructorDto);
		Task<IdentityResult> RegisterAdminAsync(RegisterDTO registerDto);
		Task<SignInResult> LoginUserAsync(LoginDTO loginDto);
		Task LogoutAsync();
		Task<GeneralUser> FindByEmailAsync(string email);
		Task<IList<string>> GetUserRolesAsync(GeneralUser user);

		Task<Instructor> GetInstructorByIdAsync(string userId);

    }
}
