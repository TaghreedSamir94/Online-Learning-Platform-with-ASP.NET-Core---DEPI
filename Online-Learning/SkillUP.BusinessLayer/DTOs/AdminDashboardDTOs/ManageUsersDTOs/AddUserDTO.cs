using SkillUP.DataAccessLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs
{
    public class AddUserDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Instructor-specific fields
        public string Education { get; set; }
        public string Description { get; set; }


        public static explicit operator GeneralUser(AddUserDTO dto)
        {
            return new GeneralUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.Email, // Set UserName as Email
                UserType = dto.Role // Set UserType based on Role
            };


        }

        public static explicit operator Instructor(AddUserDTO dto)
        {
            return new Instructor
            {
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.Email,
                UserType = dto.Role,
                Education = dto.Education,
                Description = dto.Description
            };
        }

    }
}
