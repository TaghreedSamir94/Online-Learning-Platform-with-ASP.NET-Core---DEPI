using SkillUP.BusinessLayer.DTOs.ProfileDTOs;

namespace SkillUP.VMs.ProfileVMs
{
    public class UserProfileVM
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string UserType { get; set; }
        public int? EnrollmentsCount { get; set; }



        public static UserProfileVM FromDto(UserProfileDTO profileDto)
        {
            return new UserProfileVM
            {
                FullName = profileDto.FullName,
                Email = profileDto.Email,
                Gender = profileDto.Gender.ToString(), 
                UserType = profileDto.UserType,
                EnrollmentsCount = profileDto.EnrollmentsCount
            };
        }
    }
}
