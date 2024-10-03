﻿using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using SkillUp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace SkillUp.BussinessLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        

        public UserService(UserManager<User> userManager, SignInManager<User> signinManger)
        {
            _userManager = userManager;
            _signInManager = signinManger;
        }
        public async Task<IdentityResult> RegisterUser(UserDTO user)
        {
            // identityresult msh bt3aml hasshing password
            // convert dto to identity
            IdentityResult result = await _userManager.CreateAsync(user.ToUser());

            return result;
        }

        public async Task SignIn(UserDTO user)
        {
            //persist cookies ana b7dd liha time bt3ha /session cookies time bt3ha 3la omr al session lifetime
            await _signInManager.SignInAsync(user.ToUser(), true);
        }
    }
}