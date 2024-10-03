using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.UserRequest
{
    public class CreateRoleActionRequest
    {
        [Required]
        public string RoleName { get; set; }
    }
}
