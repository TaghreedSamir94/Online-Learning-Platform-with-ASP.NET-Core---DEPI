using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.VMs.User;
using Microsoft.EntityFrameworkCore;
using SkillUp.DataAccessLayer;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SkillUp.Controllers
{
    public class AdminController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager , ApplicationDbContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContext=dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> AssignUserRoles()
        {
            var  users =_userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            var model = new RolesVMs
            {
                Users =users.Select(u => new SelectListItem { Value =u.Id, Text =u.UserName }).ToList(),
                Roles =roles.Select(u => new SelectListItem { Value =u.Id, Text =u.Name }).ToList(),

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignUserRoles(RolesVMs model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                var role = await _roleManager.FindByIdAsync(model.RoleId);

                if (user == null|| role == null)
                {
                    ModelState.AddModelError("Invalid data", "invalid User Or Role");
                }
                var result = await _userManager.AddToRoleAsync(user, role.Name);
                if (result.Succeeded)
                {
                    TempData["SuccessMassage"]=" User Has been Successfully assigned to the role";
                    return RedirectToAction(nameof(AssignUserRoles));
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        // show up all user
        public async Task<IActionResult> ListUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
        [HttpGet]
        // user to role
        public async Task<IActionResult> listUserRole()
        {
            var users = await _userManager.Users.ToListAsync();

            var userRolesList = new List<UserRolsVMs>();
            foreach (var user in users) 
            {
                var userRolesVMs = new UserRolsVMs
                {
                    UserId =user.Id,
                    UserName =user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
                userRolesList.Add(userRolesVMs);
            }
            //show me all roles in system  list mn strings
            ViewBag.AllRoles =_roleManager.Roles
                .Select( r => r.Name)
                .ToList();
           
            return View(userRolesList);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserRoles(string userid , IList<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userid);

            if (user ==null)
            {
                return NotFound();
            }
            var currentRoles = await _userManager.GetRolesAsync(user);
            // bkarn al list al adema b gdeda al haga mkntsh mwgoda a7tha "except"extanction method mn liNQ
            var rolesToAdd = roles.Except(currentRoles).ToList();
            var roleToRemove = currentRoles.Except(roles).ToList();

            await _userManager.AddToRolesAsync(user, rolesToAdd);
            await _userManager.RemoveFromRolesAsync(user, roleToRemove);

            return RedirectToAction(nameof(listUserRole));
        }

    }
}
