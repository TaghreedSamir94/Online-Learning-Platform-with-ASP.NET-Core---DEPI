using System.ComponentModel.DataAnnotations;

namespace SkillUp.VMs.RoleVMs
{
    public class AssignRoleToUserVms
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string userEmail { get; set; }
        public string roleName { get; set; }
    }
}
