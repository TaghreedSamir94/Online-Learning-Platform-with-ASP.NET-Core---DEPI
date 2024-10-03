using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.ActionRequests.UserRequest;
using SkillUp.DataAccessLayer.Entities;


namespace presantationlayer.Controllers
{
    public class RoleController : Controller
    {
        // assign role
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RoleController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost("assign-role")] // endPoint
        public async Task<IActionResult> AssignRoleToUser(AssignUserRoleActionRequset requset)
        {
            var user = await _userManager.FindByNameAsync(requset.UserName);
            // if name is not found 
            if (user == null)
            {
                return NotFound("User not Found");
            }

            // user take role or not 
            var IsUserInRole = await _userManager.IsInRoleAsync(user, requset.RoleName);

            // if role is not found in user 
            if (!IsUserInRole)
            {
                var result = await _userManager.AddToRoleAsync(user, requset.RoleName);
                if (result.Succeeded)
                {
                    return Ok("User assigned to Role Successfully ");
                }
                return BadRequest(new
                {
                    massage = "Failed to assign user to role",
                    errors = result.Errors
                });

            }
            // if role is found 
            return BadRequest($"User is already in role{requset.RoleName}");
        }
        [HttpPost("Create-role")]
        public async Task<IActionResult> CreateRoleToUser(CreateRoleActionRequest requset)
        {
            //if string null , can anyone send null string  so... (white space strnig fadya )

            if (string.IsNullOrWhiteSpace(requset.RoleName)) // validation step 
            {
                return BadRequest("Role Name cannot be empty ");
            }
            // if role in database or not  (لو انا بسال علي رول كدا محتاجه ال "roleManger")
            var IsNotExists = await _roleManager.RoleExistsAsync(requset.RoleName);
            if (!IsNotExists)
            {

                //createasync need to Identity role so i making a new object
                //var result = await _roleManager.CreateAsync(new IdentityRole(requset.RoleName));

                //if (result.Succeeded)
                //{
                //    return Created();
                //}
                //return BadRequest(new
                //{
                //    massage = "Failed to Create a new Role",
                //    errors = result.Errors
                //});
            }
            return BadRequest("Role already exists.");

        }
    }
}
