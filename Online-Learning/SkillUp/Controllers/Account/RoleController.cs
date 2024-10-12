using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkillUp.ActionRequests.RoleRequest;
using SkillUp.DataAccessLayer;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.VMs.User;
using System.Data.Entity;
using System.Reflection.Metadata.Ecma335;


namespace SkillUp.Controllers
{
    public class RoleController : Controller
    {
        // assign role
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public RoleController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserActionRequset requset)
        {
            var user = await _userManager.FindByNameAsync(requset.UserName);
            //not found userId is false
            if(user ==null)
            {
                return NotFound("User  NOt Found");
            }
            //if user have a role or not 
            var IsUserInRole = await _userManager.IsInRoleAsync(user, requset.RoleName);
            if (!IsUserInRole)
            {
             var result = await _userManager.AddToRoleAsync(user, requset.RoleName);
                if (result.Succeeded)
                {
                    return Ok("User Assigned to Role Succesfully");
                }
                return BadRequest(new
                {
                    massage ="Failed to assign user to role",
                    errors=result.Errors
                });
            }
            return BadRequest($"User is ALready in role {requset.RoleName}");
        }
        [HttpGet]
        public async Task<IActionResult> AssignUserRoles()
        {
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            var model = new RolesVMs
            {
                Users =users.Select(u => new SelectListItem { Value =u.Id, Text =u.UserName }).ToList(),
                Roles =roles.Select(u => new SelectListItem { Value =u.Id, Text =u.Name }).ToList(),

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleActionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.RoleName))
            {
                return BadRequest("role name cannot be empty");
            }
             var IsRoleExists =await _roleManager.RoleExistsAsync(request.RoleName);
            if (IsRoleExists)
            {
                return BadRequest("role already exists");
            }
                //save 
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole (request.RoleName));
                //if u succeded
                if (result.Succeeded)
                {
                return RedirectToAction("listRoles", "Admin");
                }
                // show me errors and increase to role state 
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> CreateRole()
        {
            return View();
        }
    }
}
