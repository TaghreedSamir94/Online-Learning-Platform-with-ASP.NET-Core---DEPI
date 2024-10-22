using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs;
using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.AccountDTOs
{
    public class InstructorDTO
    {
        public string Id  { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; }
        public string Education { get; set; }
        public string Description { get; set; }


        public static InstructorDTO FromUser(Instructor user)
        {
            return new InstructorDTO
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
