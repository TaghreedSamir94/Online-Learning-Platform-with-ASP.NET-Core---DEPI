using SkillUp.DataAccessLayer.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.DTOs.UsersDTOs
{
    public class RegisteredStudentDTO :GeneralUserDTO
    {
        public string University { get; set; }
    }


    public static class StudentMappingExtensions
    {
        public static Student ToEntity(this RegisteredStudentDTO dto)
        {
            return new Student
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Gender = dto.Gender,
                University = dto.University
            };
        }
       
    }
}
