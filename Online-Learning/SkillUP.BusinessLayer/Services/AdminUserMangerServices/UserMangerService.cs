using Microsoft.AspNetCore.Identity;
using SkillUP.BusinessLayer.DTOs.AccountDTOs;
using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.DataAccessLayer.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs;

namespace SkillUP.BusinessLayer.Services.AdminUserMangerServices
{
    public class UserMangerService : IUserMangerService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<GeneralUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserMangerService(IUserRepository userRepository, UserManager<GeneralUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        #region Add User
        public async Task AddUserAsync(AddUserDTO dto)
        {
            GeneralUser user;
            if (dto.Role == "Instructor")
            {
                user = (Instructor)dto; 
            }
            else
            {
                user = (GeneralUser)dto; 
            }

            user.UserName = dto.Email; 

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to add user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            if (!await _roleManager.RoleExistsAsync(dto.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(dto.Role));
            }

            
            await _userManager.AddToRoleAsync(user, dto.Role);
        }

        #endregion

        #region Delete user
        public async Task DeleteUserAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
			if (user == null)
			{
				throw new Exception("User not found");
			}

			var result = await _userManager.DeleteAsync(user);
			if (!result.Succeeded)
			{
				throw new Exception("Failed to delete user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
			}
		}

        #endregion

        #region GetAllUser
        public async Task<List<UserListDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(UserListDTO.FromUser).ToList();
        }

        #endregion 

        #region Get user by email
        public async Task<UserDetailsDTO> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return UserDetailsDTO.FromUser(user);
        }

        #endregion

        //public async Task<EditUserDTO> GetUserByIdAsync(string id)
        //{
        //    var user = await _userRepository.GetByEmailAsync(id); 
        //    if (user == null)
        //    {
        //        throw new Exception("User not found");
        //    }
        //    return EditUserDTO.MapFromUser(user);
        //}

        #region Update User
        public async Task UpdateUserAsync(EditUserDTO dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.FullName = dto.FullName;
			user.UserType = dto.Role;
			// Handle instructor-specific fields
			if (dto.Role == "Instructor")
            {
                var instructor = (Instructor)dto; 
                instructor.Education = instructor.Education; 
                instructor.Description = instructor.Description;
            }

			// Handle role change
			var currentRoles = await _userManager.GetRolesAsync(user);

			// Only proceed if the role needs to be updated
			if (!currentRoles.Any(r => r.Equals(dto.Role, StringComparison.OrdinalIgnoreCase)))
			{
				if (currentRoles.Any())
				{
					var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
					if (!removeResult.Succeeded)
					{
						throw new Exception($"Failed to remove roles: {string.Join(", ", removeResult.Errors.Select(e => e.Description))}");
					}
				}

				var addRoleResult = await _userManager.AddToRoleAsync(user, dto.Role);
				if (!addRoleResult.Succeeded)
				{
					throw new Exception($"Failed to assign new role: {string.Join(", ", addRoleResult.Errors.Select(e => e.Description))}");
				}
			}



			var updateResult = await _userManager.UpdateAsync(user);
			if (!updateResult.Succeeded)
			{
				throw new Exception($"Failed to update user: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}");
			}

        }

        #endregion


        #region GetInstructor
        public async Task<List<InstructorDTO>> GetAllInstructorsAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var instructors = users.OfType<Instructor>(); // Filter only Instructor objects
            return instructors.Select(InstructorDTO.FromUser).ToList();
        }
        #endregion


        #region Search user by Name
        public async Task<List<UserListDTO>> SearchUsersByNameAsync(string name)
        {
            var users = await _userRepository.SearchUserByName(name);
            return users.Select(UserListDTO.FromUser).ToList();
        }
        #endregion
    }
}
