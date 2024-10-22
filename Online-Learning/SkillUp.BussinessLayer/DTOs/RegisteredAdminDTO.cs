using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using SkillUp.DataAccessLayer;
using SkillUp.DataAccessLayer.Entities;

namespace SkillUp.BussinessLayer.DTOs
{
    public class RegisteredAdminDTO : GeneralUserDTO
    {
        public string Department { get; set; }
    }
    public static class AdminMappingExtensions
    {
        public static Admins ToEntity(this RegisteredAdminDTO dto)
        {
            return new Admins
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Gender = dto.Gender,
                Department =dto.Department
            };
        }
    }
}
