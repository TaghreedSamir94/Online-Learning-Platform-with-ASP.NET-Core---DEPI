using SkillUp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkillUp.BussinessLayer.DTOs
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string TypeOfUser { get; set; }

    }
    public static class RegisterUserDTOExtensiions //  capy data and updated without change the original
    {
        public static User ToUser(this UserDTO dto)
            => new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = dto.Password,
                TypeOfUser =dto.TypeOfUser

            };
    }
}
