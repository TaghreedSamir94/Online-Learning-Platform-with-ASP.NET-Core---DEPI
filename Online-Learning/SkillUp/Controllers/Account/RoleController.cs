using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.ActionRequests.RoleRequest;
using SkillUp.DataAccessLayer;
using SkillUp.DataAccessLayer.Entities;
using System.Data.Entity;


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

        [HttpPost] // Endpoint for role assignment
        public async Task<IActionResult> listRoles(listRolesActionRequset request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            // Check if the user was found
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Check if the user is already in the specified role
            var isUserInRole = await _userManager.IsInRoleAsync(user, request.RoleName);

            if (!isUserInRole)
            {
                var result = await _userManager.AddToRoleAsync(user, request.RoleName);

                if (result.Succeeded)
                {
                    return Ok("User assigned to role successfully");
                }

                return BadRequest(new
                {
                    message = "Failed to assign user to role",
                    errors = result.Errors
                });
            }

            return BadRequest($"User is already in this role.{request.RoleName}"); // Handle case where user is already in the role
        }
        [HttpGet]
        public async Task<IActionResult> listRoles()
        {
            // Use ToList() since Roles does not support asynchronous operations
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleActionRequest request)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = request.RoleName;

                //save 
                IdentityResult result = await _roleManager.CreateAsync(role);
                //if u succeded
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(listRoles));
                }
                // show me errors and increase to role state 
                foreach(IdentityError error in result.Errors)
                {
                        ModelState.AddModelError(error.Code, error.Description);
                }
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
