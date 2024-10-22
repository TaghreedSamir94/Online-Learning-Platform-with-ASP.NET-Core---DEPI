using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.BusinessLayer.DTOs.ProfileDTOs
{
    public class UserProfileDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string UserType { get; set; }
        public int EnrollmentsCount { get; set; }


        public static UserProfileDTO FromUser(GeneralUser user)
        {
            var enrollmentsCount = user is Student student ? student.Enrollments?.Count ?? 0 : 0;

            return new UserProfileDTO
            {
                FullName = user.FullName,
                Email = user.Email,
                Gender = user.Gender,
                UserType = user.UserType,
                EnrollmentsCount = enrollmentsCount
            };
        }
    }
}
