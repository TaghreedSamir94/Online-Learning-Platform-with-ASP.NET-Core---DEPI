using System.ComponentModel.DataAnnotations;

namespace SkillUp.ActionRequests.RoleRequest
{
    public class CreateRoleActionRequest
    {
        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
