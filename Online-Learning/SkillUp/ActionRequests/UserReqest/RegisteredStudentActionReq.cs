using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using SkillUp.DataAccessLayer.Enums;
using SkillUp.VMs.AccountVMs;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.UserReqest
{
    public class RegisteredStudentActionReq
    {
        [Required(ErrorMessage = "There is an issue with either the Username ")]
        [StringLength(100, ErrorMessage = "name cannot exceed 100 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "password must be at least {2} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password and Confirm is not match")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "There is an issue with either the  Email.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string? University { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }

        public static explicit operator RegisteredStudentActionReq(RegisteredStudentVM v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v), "RegisteredStudentVM cannot be null");
            }

            return new RegisteredStudentActionReq
            {
                UserName = v.UserName,
                Password = v.Password, // Assuming the VM has a Password property
                ConfirmPassword = v.ConfirmPassword, // Assuming the VM has a ConfirmPassword property
                Email = v.Email,
                Gender=v.Gender,
                University = v.University
            };
        }
    }
    public static class RegisterUserExtensions
    {
        public static RegisteredStudentDTO ToDTO(this RegisteredStudentActionReq newAccount)
        =>
            new RegisteredStudentDTO
            {
                UserName = newAccount.UserName,
                Password = newAccount.Password,
                Email = newAccount.Email,
                Gender = newAccount.Gender,
                University =newAccount.University
            };
    }
}
