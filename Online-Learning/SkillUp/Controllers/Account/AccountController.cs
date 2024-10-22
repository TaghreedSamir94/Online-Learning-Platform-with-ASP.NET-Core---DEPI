using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SkillUp.ActionRequests.UserReqest;
using SkillUp.DataAccessLayer;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.VMs.AccountVMs;

namespace SkillUp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<GeneralUser> _signInManager;
        private readonly UserManager<GeneralUser> _UserManager; //to allow me to read from app setting 
        private readonly ILogger<AccountController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<GeneralUser> signInManager, UserManager<GeneralUser> userManager, ILogger<AccountController> logger, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _UserManager = userManager;
            _logger = logger;
            _roleManager =roleManager;
        }

        #region StudentRegister 
        //Register Create a new Student or Instructor 
        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisteredStudentVM registerStudentVM)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    _logger.LogWarning("Model state error: {Error}", error);
                }
                return View(registerStudentVM); //return vm on validation failure
            }
            // convert vm to action requset
            var request = (RegisteredStudentActionReq)registerStudentVM;

            var existingUser = await _UserManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "you are already Registered");
                return View(request);
            }

            //create new student
            var students = new Student
            {
                UserName = request.UserName,
                Email = request.Email,
                Gender = request.Gender,
                University=request.University
            };
            // user cannot find ...
            IdentityResult result = await _UserManager.CreateAsync(students, request.Password);

            if (result.Succeeded)
            {
                // Add role 'Student' to the user
                if (!await _roleManager.RoleExistsAsync("Student"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Student"));
                }
                await _UserManager.AddToRoleAsync(students, "Student");

                await _signInManager.SignInAsync(students, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            // handel creation erroes
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            // if no action is ture show the reason
            return View(registerStudentVM);
        }
        // GET: Register student
        [HttpGet]
        public async Task<IActionResult> RegisterStudent()
        {
            return View("RegisterStudent");
        }
        #endregion

        #region RegisterAdmin
        //Register Create a new Admin
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisteredAdminVM registeAdminVM)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    _logger.LogWarning("Model state error: {Error}", error);
                }
                return View(registeAdminVM); //return vm on validation failure
            }

            // convert vm to action requset
            var request = (RegisteredAdminActionReq)registeAdminVM;

            var existingUser = await _UserManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "you are already Registered");
                return View(request);
            }

            //create new admin
            var admins = new Admins
            {
                UserName =request.UserName,
                Email =request.Email,
                Gender = request.Gender,
                Department=request.Department
            };
            // user cannot find ...
            var result = await _UserManager.CreateAsync(admins, request.Password); // Use 'admins' here

            if (result.Succeeded)
            {
                // Add role 'Admin' to the user
                if (!await _roleManager.RoleExistsAsync("Admins"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admins"));
                }
                await _UserManager.AddToRoleAsync(admins, "Admins");

                await _signInManager.SignInAsync(admins, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        return View(registeAdminVM);
        }
        // Get :Register admin
       [HttpGet]
        public async Task<IActionResult> RegisterAdmin()
        {
            return View("RegisterAdmin");
        }
        #endregion

        #region InstructorRegister
        //Register Create a new Admin
        [HttpPost]
        public async Task<IActionResult> RegisterInstructor(RegisteredInstructorVM registeInstructorVM)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    _logger.LogWarning("Model state error: {Error}", error);
                }
                return View(registeInstructorVM); //return vm on validation failure
            }

            // convert vm to action requset
            var request = (RegisteredInstructorActionReq)registeInstructorVM;

            var existingUser = await _UserManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "you are already Registered");
                return View(request);
            }

            //create new admin
            var instructors = new Instructor
            {
                UserName =request.UserName,
                Email =request.Email,
                Gender = request.Gender,
                Description =request.Description,
                Education =request.Education
            };
            var result = await _UserManager.CreateAsync(instructors, request.Password);
            if (result.Succeeded)
            {
                // Add role 'Instructor' to the user
                if (!await _roleManager.RoleExistsAsync("Instructor"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Instructor"));
                }
                await _UserManager.AddToRoleAsync(instructors, "Instructor");

                await _signInManager.SignInAsync(instructors, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(registeInstructorVM);
        }
        // GET :Register Instructor
        [HttpGet]
        public async Task<IActionResult> RegisterInstructor()
        {
            return View("RegisterInstructor");
        }
        #endregion

        #region lOGin LOGOUT
        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            return View("SignIn");
        }
        // log in user 
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInVM signInVM, string ReturnUrl)
        {
            var request = (SignInActionRequest)signInVM;

            // found user name
            var user = await _UserManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, request.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //check user role ande redirect accordingly
                    var roles = await _UserManager.GetRolesAsync(user);

                    if (roles.Contains("Admins"))
                    {
                        if (!string.IsNullOrEmpty(ReturnUrl))
                        {
                            return LocalRedirect(ReturnUrl);
                        }
                        return RedirectToAction("index", "Courses");
                    }
                    else if (roles.Contains("Student"))
                    {
                        if (!string.IsNullOrEmpty(ReturnUrl))
                        {
                            return LocalRedirect(ReturnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else if (roles.Contains("Instructor"))
                    {
                        if (!string.IsNullOrEmpty(ReturnUrl))
                        {
                            return LocalRedirect(ReturnUrl);
                        }
                        return RedirectToAction("", "");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(ReturnUrl))
                        {
                            return LocalRedirect(ReturnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            //create a cookie
            await _signInManager.SignInAsync(user, request.RememberMe);
            return View(signInVM);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
    } 
    #endregion
} 

