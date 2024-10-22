using SkillUP.BusinessLayer.DTOs.ProfileDTOs;
using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.DataAccessLayer.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.Services.ProfileServices
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;

        public ProfileService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserProfileDTO> GetUserProfileByIdAsync(string userId)
        {
            var user = await _userRepository.GetStudProfileByIdAsync(userId);
            if (user == null)
            {
                return null;
            }
            return UserProfileDTO.FromUser(user);

        }
    }
}
