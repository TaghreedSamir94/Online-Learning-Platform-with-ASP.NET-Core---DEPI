using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.Services.Users
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUser(UserDTO user);
        Task SignIn(UserDTO user);
    }
}
