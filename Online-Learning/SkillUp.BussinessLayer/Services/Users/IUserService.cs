using Microsoft.AspNetCore.Identity;
using SkillUp.BussinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.Services
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUser(UserDTO user);
        Task SignIn(UserDTO user);
    }
}
