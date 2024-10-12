using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkillUp.ActionRequests.RoleRequest;
using SkillUp.DataAccessLayer;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.VMs.User;
using System.Data.Entity;


namespace SkillUp.Controllers
{
    [Authorize(Roles ="Admin")]
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

//[HttpPost]
//public async Task<IActionResult> AssignUserRoles(RolesVMs model)
//{
//    if (ModelState.IsValid)
//    {
//        var user = await _userManager.FindByIdAsync(model.UserId);
//        var role = await _roleManager.FindByIdAsync(model.RoleId);

//        if (user == null|| role == null)
//        {
//            ModelState.AddModelError("Invalid data", "invalid User Or Role");
//        }
//        var result = await _userManager.AddToRoleAsync(user, role.Name); //role "string"
//        if (result.Succeeded)
//        {
//            TempData["SuccessMassage"]=" User Has been Successfully assigned to the role";
//            return RedirectToAction(nameof(AssignUserRoles));
//        }
//        foreach (var error in result.Errors)
//        {
//            ModelState.AddModelError(error.Code, error.Description);
//        }
//    }
//    return View(model);
//}