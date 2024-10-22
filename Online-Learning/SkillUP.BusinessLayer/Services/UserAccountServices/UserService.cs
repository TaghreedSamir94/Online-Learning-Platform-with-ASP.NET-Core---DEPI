using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillUP.BusinessLayer.DTOs.AccountDTOs;
using SkillUP.DataAccessLayer.Data;
using SkillUP.DataAccessLayer.Entities.Users;



namespace SkillUP.BusinessLayer.Services.UserAccountServices
{
	public class UserService : IUserService
	{
		private readonly UserManager<GeneralUser> _userManager;
		private readonly SignInManager<GeneralUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public UserService(UserManager<GeneralUser> userManager,SignInManager<GeneralUser> signInManager,RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
            _context = context;
        }


		public async Task<IdentityResult> RegisterUserAsync(RegisterDTO registerDto)
		{
			var user = (GeneralUser)registerDto; // Explicit operator conversion from DTO to Entity

			var result = await _userManager.CreateAsync(user, registerDto.Password);
			if (result.Succeeded)
			{
				// Assign "Student" role by default
				await _userManager.AddToRoleAsync(user, "Student");
			}

			return result;
		}

		public async Task<IdentityResult> RegisterInstructorAsync(RegisterInstructorDTO registerInstructorDto)
		{
			var instructor = (Instructor)registerInstructorDto; // Explicit conversion to Instructor entity

			var result = await _userManager.CreateAsync(instructor, registerInstructorDto.Password);
			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(instructor, "Instructor");
			}

			return result;
		}


		public async Task<IdentityResult> RegisterAdminAsync(RegisterDTO registerDto)
		{
			var admin = (GeneralUser)registerDto;
			var result = await _userManager.CreateAsync(admin, registerDto.Password);

			if (result.Succeeded)
			{
				// Assign Admin role
				await _userManager.AddToRoleAsync(admin, "Admin");
			}
			return result;
		}

		public async Task<SignInResult> LoginUserAsync(LoginDTO loginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, loginDto.RememberMe, lockoutOnFailure: false);
			return result;
		}

		public async Task LogoutAsync()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<GeneralUser> FindByEmailAsync(string email)
		{
			return await _userManager.FindByEmailAsync(email);
		}

		public async Task<IList<string>> GetUserRolesAsync(GeneralUser user)
		{
			return await _userManager.GetRolesAsync(user);
		}

        public async Task<Instructor> GetInstructorByIdAsync(string userId)
        {
            return await _context.Instructors
                .FirstOrDefaultAsync(i => i.Id == userId);
        }
    }

}
