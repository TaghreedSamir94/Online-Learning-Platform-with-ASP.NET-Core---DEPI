using SkillUP.DataAccessLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs
{
    public class EditUserDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Instructor-specific fields
        public string Education { get; set; }
        public string Description { get; set; }



        public static explicit operator GeneralUser(EditUserDTO dto)
        {
            return new GeneralUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.Email,
                UserType = dto.Role,

            };


        }

        public static explicit operator Instructor(EditUserDTO dto)
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

        public static EditUserDTO MapFromUser(GeneralUser user)
        {
            if (user is Instructor instructor)
            {
                return new EditUserDTO
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.UserType,
                    Education = instructor.Education,
                    Description = instructor.Description
                };
            }

            return new EditUserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.UserType
            };
        }



    }
}
