using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.UserRequest
{
    public class CreateUserActionRequest
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

        [Required(ErrorMessage = "Type of User is required")]
        public string TypeOfUser { get; set; }
        //public List<string> Errors { get; set; }

    }
    public static class RegisterUserExtensions
    {
        public static UserDTO ToDTO(this CreateUserActionRequest newAccount)
        =>
            new UserDTO
            {
                UserName = newAccount.UserName,
                Password = newAccount.Password,
                TypeOfUser = newAccount.TypeOfUser,
                Email = newAccount.Email,
            };
    }
}

