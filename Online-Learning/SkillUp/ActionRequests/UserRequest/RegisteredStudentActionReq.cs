using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using SkillUp.DataAccessLayer.Enums;
using SkillUp.VMs.AccountVMs;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.UserRequest
{
    public class RegisteredStudentActionReq
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

        [Required(ErrorMessage = "University is required")]
        public string University { get; set; } = string.Empty;


        public static explicit operator RegisteredStudentActionReq(RegisteredStudentVM vm)
        {
            return new RegisteredStudentActionReq
            {
                UserName = vm.UserName,
                Email = vm.Email,
                Password = vm.Password,
                ConfirmPassword = vm.ConfirmPassword,
                University = vm.University,
                Gender = vm.Gender
            };
        }

        // Convert ActionReq to DTO for service use
        public RegisteredStudentDTO ToDTO()
        {
            return new RegisteredStudentDTO
            {
                UserName = this.UserName,
                Email = this.Email,
                Password = this.Password,
                ConfirmPassword = this.ConfirmPassword,
                University = this.University,
                Gender = this.Gender
            };
        }

    }
}
