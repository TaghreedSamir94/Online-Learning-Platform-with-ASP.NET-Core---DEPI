using SkillUp.DataAccessLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.VMs.AccountVMs
{
    public class RegisteredStudentVM
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


    }
}
