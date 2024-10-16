using SkillUp.DataAccessLayer.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.DTOs.UsersDTOs
{
    public class RegisteredInstructorDTO : GeneralUserDTO
    {
        public string Education { get; set; }
        public string Description { get; set; }
    }

    public static class InstructorMappingExtensions
    {
        public static Instructor ToEntity(this RegisteredInstructorDTO dto)
        {
            return new Instructor
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Gender = dto.Gender,
                Education = dto.Education,
                Description = dto.Description,
               
            };
        }


    
    }
}
