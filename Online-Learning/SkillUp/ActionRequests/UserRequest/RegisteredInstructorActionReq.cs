using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using SkillUp.DataAccessLayer.Enums;
using SkillUp.VMs.AccountVMs;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.UserRequest
{
    public class RegisteredInstructorActionReq
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

        [Required(ErrorMessage = "Education is required")]
        public string Education { get; set; }

        [StringLength(800, ErrorMessage = "Description cannot exceed 800 characters")]
        public string Description { get; set; }


        public static explicit operator RegisteredInstructorActionReq(RegisteredInstructorVM vm)
        {
            return new RegisteredInstructorActionReq
            {
                UserName = vm.UserName,
                Email = vm.Email,
                Password = vm.Password,
                Education = vm.Education,
                Description = vm.Description,     
                Gender = vm.Gender
            };
        }

        // Convert ActionReq to DTO for service use
        public static explicit operator RegisteredInstructorDTO(RegisteredInstructorActionReq req)
        {
            return new RegisteredInstructorDTO
            {
                UserName = req.UserName,
                Email = req.Email,
                Password = req.Password,
                ConfirmPassword = req.ConfirmPassword,
                Gender = req.Gender,
                Education=req.Education,
                Description = req.Description,
            };
        }
    }
}
