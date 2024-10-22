using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUP.ActionRequests.UsersActionReq;
using SkillUP.BusinessLayer.DTOs.AccountDTOs;
using SkillUP.BusinessLayer.Services.UserAccountServices;
using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.VMs.AccountVMs;

namespace SkillUP.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUserService _userService;
		private readonly UserManager<GeneralUser> _userManager;

		public AccountController(IUserService userService, UserManager<GeneralUser> userManager)
		{
			_userService = userService;
			_userManager = userManager;
		}

		#region Student Register
		public IActionResult RegisterStudent()
		{
			return View("RegisterStudent");
		}

		[HttpPost]
		public async Task<IActionResult> RegisterStudent(RegisteredStudentActionReq request)
		{
			if (!ModelState.IsValid) return View(request.ToVM());

			var dto = (RegisterDTO)request;
			var result = await _userService.RegisterUserAsync(dto);

			if (result.Succeeded)
			{
				 return RedirectToAction("Login", "Account");
			}

			foreach (var error in result.Errors) 
			{
                ModelState.AddModelError("", error.Description);
            }
				

			return View(request.ToVM());
		}

		#endregion

		#region Instructor Register
		public IActionResult RegisterInstructor() 
		{
			return View("RegisterInstructor");
		} 

		[HttpPost]
		public async Task<IActionResult> RegisterInstructor(RegisteredInstructorActionReq request)
		{
			if (!ModelState.IsValid) return View(request.ToVM);

			var dto = (RegisterInstructorDTO)request;
			var result = await _userService.RegisterInstructorAsync(dto);

			if (result.Succeeded)
			{
                var user = await _userService.FindByEmailAsync(dto.Email);
                if (user is Instructor instructor)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Instructor not found.");
                }
            }

			foreach (var error in result.Errors)
				ModelState.AddModelError("", error.Description);

			return View(request.ToVM);
		}

		#endregion

		#region Admin Register
		public IActionResult RegisterAdmin()
		{
			return View("RegisterAdmin");
		}

		[HttpPost]
		public async Task<IActionResult> RegisterAdmin(RegisteredAdminActionReq request)
		{
			if (!ModelState.IsValid) return View(request.ToVM());

			var dto = (RegisterDTO)request;
			var result = await _userService.RegisterAdminAsync(dto);

			if (result.Succeeded)
			{
                return RedirectToAction("Login", "Account");
            }

			foreach (var error in result.Errors)
				ModelState.AddModelError("", error.Description);

			return View(request.ToVM());
		}

        #endregion


        #region Login
        [HttpGet]
        public IActionResult Login() 
		{
			return View("Login");
		}
        [HttpPost]
        public async Task<IActionResult> Login(LoginActionReq request)
		{
			if (!ModelState.IsValid)
			{ return View(request.ToVM()); }

			var dto = (LoginDTO)request;
			var result = await _userService.LoginUserAsync(dto);



			if (result.Succeeded)
			{
				var user = await _userService.FindByEmailAsync(request.Email);
                var roles = await _userService.GetUserRolesAsync(user);

				if (roles.Contains("Admin")) return RedirectToAction("Index", "AdminDashboard");
                if (roles.Contains("Instructor"))
                {
                    var instructor = await _userService.GetInstructorByIdAsync(user.Id);
                    return View("InstructorHomePage", instructor);
                }
                return RedirectToAction("Index", "Home");
			}

			ModelState.AddModelError("", "Invalid login attempt");
			return View(request.ToVM());
		}


		#endregion

		#region Logout
		public async Task<IActionResult> Logout()
		{
			await _userService.LogoutAsync();
			return RedirectToAction("Index", "Home");
		}
		#endregion
	}
}
