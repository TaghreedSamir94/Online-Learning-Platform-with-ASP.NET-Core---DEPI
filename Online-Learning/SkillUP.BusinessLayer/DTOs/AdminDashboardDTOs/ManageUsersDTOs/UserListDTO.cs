using SkillUP.DataAccessLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs
{
    public class UserListDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Instructor-specific fields
        public string Education { get; set; }
        public string Description { get; set; }

        public static explicit operator GeneralUser(UserListDTO dto)
        {
            return new GeneralUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.Email, // Set UserName as Email
                UserType = dto.Role // Set UserType based on Role
            };


        }

        public static explicit operator Instructor(UserListDTO dto)
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

        // Mapping function
        public static UserListDTO FromUser(GeneralUser user)
        {
            return new UserListDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.UserType,
                Education = user is Instructor instructor ? instructor.Education : null,
                Description = user is Instructor instructorDescription ? instructorDescription.Description : null
            };
        }

    }
}
