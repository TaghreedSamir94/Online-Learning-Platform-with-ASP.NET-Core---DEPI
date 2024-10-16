using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using SkillUp.DataAccessLayer.Enums;
using SkillUp.VMs.AccountVMs;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.UserRequest
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


        public static explicit operator RegisteredAdminActionReq(RegisteredAdminVM vm)
        {
            return new RegisteredAdminActionReq
            {
                UserName = vm.UserName,
                Email = vm.Email,
                Password = vm.Password,
                Department = vm.Department,
                Gender = vm.Gender
            };
        }


        // Convert ActionReq to DTO for service use
        public static explicit operator RegisteredAdminDTO(RegisteredAdminActionReq req)
        {
            return new RegisteredAdminDTO
            {
                UserName = req.UserName,
                Email = req.Email,
                Password = req.Password,
                ConfirmPassword = req.ConfirmPassword,
                Gender = req.Gender,
                Department = req.Department
            };
        }
    }
}
