
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUp.ActionRequests.UserRequest;
using SkillUp.DataAccessLayer.Entities;

namespace SkillUp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _UserManager; //to allow me to read from app setting 


        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _UserManager = userManager;

        }


        //Register Create a new Student or Instructor 

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserActionRequest Request, string ReturnUrl)
        {
            var existingUser = await _UserManager.FindByNameAsync(Request.UserName);

            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "you are already Registered");
                return View(Request);
            }

            var user = new User
            {
                UserName = Request.UserName,
                Email = Request.Email,
                TypeOfUser = Request.TypeOfUser
            };

            if (existingUser != null)
            {
                // if user is registered then check pass
                var passwordValid = await _UserManager.CheckPasswordAsync(existingUser, Request.Password);

                if (passwordValid)
                {
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    // if pass is true then goto action sigin
                    return RedirectToAction("SignIn", "Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "There is an issue with password ");
                }
            }
            else
            {
                // user cannot find ...
                IdentityResult result = await _UserManager.CreateAsync(user, Request.Password);

                if (result.Succeeded)
                {
                    //await _signInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // any error show up 
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // if no action is ture show the reason
            return View(Request);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }


        [HttpGet("SignIn")]
        public async Task<IActionResult> SignIn()
        {
            return View();
        }
        // log in user 
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInActionRequest request)
        {
            var user = await _UserManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                var IsPasswordValid = await _UserManager.CheckPasswordAsync(user, request.Password);
                if (IsPasswordValid)
                {
                    return Unauthorized(); //401 erorr
                }
            }
            return RedirectToAction("Account", "Register");
        }
    }
}

