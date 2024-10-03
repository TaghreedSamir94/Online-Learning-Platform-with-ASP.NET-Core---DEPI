using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.VMs.AccountVMs
{
    public class SignInVMs
    {
        [Required(ErrorMessage = " UserName is required")]
        [StringLength(250, ErrorMessage = "UserName cannot be longer than 250 characters")]
        [Display(Name = " Username")]
        public string UserName { get; set; }



        [Required(ErrorMessage = "Email is required")]
        [Display(Name = " Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // third-party login provider

        public IEnumerable<AuthenticationScheme> schemes { get; set; }
    }
}
