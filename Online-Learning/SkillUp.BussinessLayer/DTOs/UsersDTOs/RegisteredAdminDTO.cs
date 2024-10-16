using SkillUp.DataAccessLayer.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.BussinessLayer.DTOs.UsersDTOs
{
    public class RegisteredAdminDTO : GeneralUserDTO
    {
        public string Department { get; set; } = "Administration";
    }

        public static class AdminMappingExtensions
        {
            public static Admin ToEntity(this RegisteredAdminDTO dto)
            {
                return new Admin
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    Gender = dto.Gender,
                    Department = dto.Department
                };
            }


            public static RegisteredAdminDTO ToDTO(this Admin admin)
            {
                return new RegisteredAdminDTO
                {
                    UserName = admin.UserName,
                    Email = admin.Email,
                    Gender = admin.Gender,
                    Department = admin.Department
                };
            }
        }
    
}
