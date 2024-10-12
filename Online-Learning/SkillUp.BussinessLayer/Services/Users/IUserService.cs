using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillUp.DataAccessLayer.Entities.UserEntities;

namespace SkillUp.BussinessLayer.Services.Users
{
    public interface IUserService
    {
        Task<ResultDTO> RegisterStudentAsync(RegisteredStudentDTO studentDto);
        Task<ResultDTO> RegisterInstructorAsync(RegisteredInstructorDTO instructorDto);
        Task<ResultDTO> RegisterAdminAsync(RegisteredAdminDTO adminDto);
        Task<SignInResult> LoginAsync(LoginDTO loginDto);
        Task LogoutAsync();
    }
}
