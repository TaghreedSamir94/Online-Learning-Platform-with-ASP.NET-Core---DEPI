using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.UserRequest
{
    public class LoginActionReq
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        [DataType(DataType.Password)]    
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } = false;
    }
}
