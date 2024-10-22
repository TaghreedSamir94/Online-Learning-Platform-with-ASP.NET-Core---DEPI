using Microsoft.AspNetCore.Mvc.Rendering;

namespace SkillUp.ActionRequests.RoleRequest
{
    public class AssignRoleToUserActionRequset
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
    }
}
