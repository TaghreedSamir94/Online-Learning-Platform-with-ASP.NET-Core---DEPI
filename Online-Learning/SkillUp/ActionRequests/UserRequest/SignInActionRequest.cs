using SkillUp.BussinessLayer.DTOs;
using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.UserRequest
{
    public class SignInActionRequest
    {

        [Required(ErrorMessage = "There is an issue with either the Username ")]
        [StringLength(100, ErrorMessage = "name cannot exceed 100 characters")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "password must be at least {2} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public static class SignInUserExtensions
    {
        public static UserDTO ToDTO(this SignInActionRequest newAccount)
        =>
            new UserDTO
            {
                UserName = newAccount.UserName,
                Password = newAccount.Password,
            };
    }
}
