using SkillUP.BusinessLayer.DTOs.AccountDTOs;

namespace SkillUP.VMs.AdminDashboardVMs.MangerUserVMs
{
    public class InstructorVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Education { get; set; }
        public string Description { get; set; }

        public static InstructorVM MapFromDto(InstructorDTO dto)
        {
            return new InstructorVM
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Education = dto.Education,
                Description = dto.Description,
            };
        }
    }
}
