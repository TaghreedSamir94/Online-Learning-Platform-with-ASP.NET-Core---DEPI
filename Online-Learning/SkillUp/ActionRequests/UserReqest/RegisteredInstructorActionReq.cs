using SkillUp.DataAccessLayer.Enums;
using SkillUp.VMs.AccountVMs;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.UserReqest
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

        [Required(ErrorMessage = "Education  is required")]
        public string? Education { get; set; }

        [Required(ErrorMessage = "Description  is required")]
        public string? Description { get; set; }


        public static explicit operator RegisteredInstructorActionReq(RegisteredInstructorVM v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v), "RegisteredInstructorVM cannot be null");
            }
            return new RegisteredInstructorActionReq
            {
                UserName = v.UserName,
                Password = v.Password, // Assuming the VM has a Password property
                ConfirmPassword = v.ConfirmPassword, // Assuming the VM has a ConfirmPassword property
                Email = v.Email,
                Gender=v.Gender,
                Description =v.Description,
                Education = v.Education
            };
        }
    }
}

