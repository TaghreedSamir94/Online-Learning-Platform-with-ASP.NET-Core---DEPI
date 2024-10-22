using SkillUP.BusinessLayer.DTOs.ProfileDTOs;
using SkillUP.DataAccessLayer.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.Services.ProfileServices
{
    public interface IProfileService
    {
        Task<UserProfileDTO> GetUserProfileByIdAsync(string userId);

    }
}
