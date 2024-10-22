using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.DTOs.UsersDTOs
{
    public class GeneralUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public static class GeneralUserMappingExtensions
    {
        public static GeneralUser ToEntity(this GeneralUserDTO dto)
        {
            return new GeneralUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Gender = dto.Gender,
            };
        }

    }
}
