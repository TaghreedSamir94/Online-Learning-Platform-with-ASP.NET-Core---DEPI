﻿using SkillUp.ActionRequests.UserReqest;
using SkillUp.BussinessLayer.DTOs;
using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using SkillUp.DataAccessLayer.Enums;
using SkillUp.VMs.AccountVMs;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.UserReqest
{
    public class RegisteredAdminActionReq
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(30, ErrorMessage = "Username cannot be longer than 30 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password and Confirm is not match")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public GenderEnum Gender { get; set; }

        [Required(ErrorMessage = "Department Code is required")]
        public string Department { get; set; }

        public static explicit operator RegisteredAdminActionReq(RegisteredAdminVM v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v), "RegisteredStudentVM cannot be null");
            }
            return new RegisteredAdminActionReq
            {
                UserName = v.UserName,
                Password = v.Password, // Assuming the VM has a Password property
                ConfirmPassword = v.ConfirmPassword, // Assuming the VM has a ConfirmPassword property
                Email = v.Email,
                Gender=v.Gender,
                Department =v.Department
            };
        } 
    }
        
}


