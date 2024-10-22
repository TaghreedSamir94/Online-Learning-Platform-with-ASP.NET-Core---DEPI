using SkillUp.VMs.AccountVMs;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.UserReqest
{
    public class SignInActionRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } = false;

        public static explicit operator SignInActionRequest(SignInVM v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v), "RegisteredInstructorVM cannot be null");
            }
            return new SignInActionRequest
            {
             Email=v.Email,
             Password=v.Password,
             RememberMe=v.RememberMe
            };
        }
    }
}
