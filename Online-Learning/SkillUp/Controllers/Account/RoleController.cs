using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.ActionRequests.RoleRequest;
using SkillUp.DataAccessLayer;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.VMs;
using System.Data.Entity;
using System.Drawing.Printing;


namespace SkillUp.Controllers
{
    public class RoleController : Controller
    {
        // assign role
        private readonly UserManager<GeneralUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public RoleController(UserManager<GeneralUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> AssignRoleToUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(string userEmail, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            //not found userId is false
            if (user !=null)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (roleExists)
                {
                    var result = await _userManager.AddToRoleAsync(user, roleName);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserRoleList", new { email = userEmail });
                    }
                }
            }
            ModelState.AddModelError("", "Role assigment failed.");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleActionRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.RoleName))
            {
                var roleExists = await _roleManager.RoleExistsAsync(request.RoleName);
                if (!roleExists)
                {
                    IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(request.RoleName));
                    if (result.Succeeded)
                    {
                        return RedirectToAction("RoleList");
                    }
                }
            }
            ModelState.AddModelError("", "role creation failed or role alrady exists.");
            return View();

        }
        //get :list all roles
        [HttpGet]
        public IActionResult RoleList()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        //get  : list roles for a specific user
        [HttpGet]
        public async Task<IActionResult> UserRoleList(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return NotFound();
            }
            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.UserEmail =email;
            return View(roles);
        }

    }
}
