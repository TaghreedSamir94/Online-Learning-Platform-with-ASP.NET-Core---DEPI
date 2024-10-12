using Microsoft.AspNetCore.Mvc.Rendering;

namespace SkillUp.VMs.User
{
    public class RolesVMs
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
        
    }
}
