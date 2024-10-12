
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.ActionRequests.UserRequest;
using SkillUp.BussinessLayer.DTOs.UsersDTOs;
using SkillUp.BussinessLayer.Services.Users;
using SkillUp.DataAccessLayer.Entities.UserEntities;
using SkillUp.VMs.AccountVMs;

namespace SkillUp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly SignInManager<GeneralUser> _signInManager;

        public AccountController(IUserService userService, SignInManager<GeneralUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }


        #region Registration for Student
        public IActionResult RegisterStudent()
        {
            return View("StudentRegister");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisteredStudentVM registerStudentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerStudentVM);
            }
            var request = (RegisteredStudentActionReq)registerStudentVM;

            RegisteredStudentDTO? dto = request.ToDTO();

            var result = await _userService.RegisterStudentAsync(dto);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            // Print errors to console (or log them)
            Console.WriteLine(result.ErrorMessage);

            ModelState.AddModelError(string.Empty, result.ErrorMessage);

            return View(registerStudentVM);
        }

        #endregion


        #region Registration for Instructors

        public IActionResult RegisterInstructor()
        {
            return View("InstructorRegister");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterInstructor(RegisteredInstructorVM registerInstructorVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerInstructorVM);
            }

            var req = (RegisteredInstructorActionReq)registerInstructorVM;

            RegisteredInstructorDTO dto = (RegisteredInstructorDTO)req;

            var result = await _userService.RegisterInstructorAsync(dto);

            if (result.IsSuccess)
            {
                return RedirectToAction("InstructorPage","Shared");
            }

            ModelState.AddModelError(string.Empty, result.ErrorMessage);
            return View(registerInstructorVM);
        }
        #endregion


        #region Registration for Admins

        public IActionResult RegisterAdmin()
        {
            return View("AdminrRegister");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisteredAdminVM registerAdminVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerAdminVM);
            }

            var req = (RegisteredAdminActionReq)registerAdminVM;

            RegisteredAdminDTO dto = (RegisteredAdminDTO)req;

            var result = await _userService.RegisterAdminAsync(dto);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Courses");
            }

            ModelState.AddModelError(string.Empty, result.ErrorMessage);
            return View(registerAdminVM);
        }
        #endregion



    }
}

