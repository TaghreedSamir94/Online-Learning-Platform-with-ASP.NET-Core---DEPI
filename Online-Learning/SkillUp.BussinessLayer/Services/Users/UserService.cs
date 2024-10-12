using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using Microsoft.AspNetCore.Identity;
using SkillUp.DataAccessLayer.Entities.UserEntities;

namespace SkillUp.BussinessLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<GeneralUser> _userManager;
        private readonly SignInManager<GeneralUser> _signInManager;
        

        public UserService(UserManager<GeneralUser> userManager, SignInManager<GeneralUser> signinManger)
        {
            _userManager = userManager;
            _signInManager = signinManger;
        }

        public async Task<SignInResult> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return SignInResult.Failed; // User not fond
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.RememberMe, lockoutOnFailure: false);
            return result; 
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ResultDTO> RegisterAdminAsync(RegisteredAdminDTO adminDto)
        {
            var admin = adminDto.ToEntity(); //  extension method to map DTO to entity
            var result = await _userManager.CreateAsync(admin, adminDto.Password);
            return new ResultDTO
            {
                IsSuccess = result.Succeeded,
                ErrorMessage = result.Succeeded ? string.Empty : string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }

        public async Task<ResultDTO> RegisterInstructorAsync(RegisteredInstructorDTO instructorDto)
        {
            var instructor = instructorDto.ToEntity(); //  extension method to map DTO to entity
            var result =  await _userManager.CreateAsync(instructor, instructorDto.Password);
            return new ResultDTO
            {
                IsSuccess = result.Succeeded,
                ErrorMessage = result.Succeeded ? string.Empty : string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }

        public async Task<ResultDTO> RegisterStudentAsync(RegisteredStudentDTO studentDto)
        {
            var student = studentDto.ToEntity(); //  extension method to map DTO to entity
            var result = await _userManager.CreateAsync(student, studentDto.Password);
            return new ResultDTO
            {
                IsSuccess = result.Succeeded,
                ErrorMessage = result.Succeeded ? string.Empty : string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }
    }
}
