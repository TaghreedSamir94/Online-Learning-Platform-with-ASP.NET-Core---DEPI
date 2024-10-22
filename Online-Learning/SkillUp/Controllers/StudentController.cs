using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUP.BusinessLayer.DTOs.EnrollmentDTOs;
using SkillUP.BusinessLayer.Services.AdminCourseMangerServices;
using SkillUP.BusinessLayer.Services.EnrollmentServices;
using SkillUP.BusinessLayer.Services.ProfileServices;
using SkillUP.BusinessLayer.Services.UserAccountServices;
using SkillUP.DataAccessLayer.Entities;
using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.VMs.ProfileVMs;


namespace SkillUP.Controllers
{
    [Authorize(Policy = "RequireStudentRole")]
    public class StudentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly ICourseServices _courseService;
        private readonly IUserService _userService;
        private readonly IProfileService _profService;
        private readonly UserManager<GeneralUser> _userManager;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, IEnrollmentService enrollmentService, ICourseServices courseService, IUserService userService, UserManager<GeneralUser> userManager, IProfileService profService)
        {
            _logger = logger;
            _enrollmentService = enrollmentService;
            _courseService = courseService;
            _userService = userService;
            _userManager = userManager;
            _profService = profService;
        }

        [HttpPost]
        public async Task<IActionResult> EnrollInCourse(int courseId)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _enrollmentService.EnrollInCourseAsync(user.Id, courseId);
            _logger.LogInformation($"Enrollment Result: {result}");
            if (result)
            {
                TempData["success"] = "You have successfully enrolled in the course.";
                List<EnrollmentDTO> enrollmentList = await _enrollmentService.GetEnrollmentsDTOSByStudentIdAsync(user.Id);
                List<Enrollment> enrollmententity = enrollmentList.Select(e => (Enrollment)e).ToList();

                return View("MyEnrollments", enrollmententity);
            }
            TempData["error"] = "Enrollment failed. You might be already enrolled in this course.";
            return RedirectToAction("GetCourseDetails", "Home", new { id = courseId });
        }


        public async Task<IActionResult> MyCourses()
        {
            var user = await _userManager.GetUserAsync(User);
            var enrolledCourses = await _enrollmentService.GetEnrollmentsDTOSByStudentIdAsync(user.Id);
            List<Enrollment> enrollmententity = enrolledCourses.Select(e => (Enrollment)e).ToList();

            return View("MyEnrollments", enrollmententity); 
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id; 
            var profileDto = await _profService.GetUserProfileByIdAsync(userId);

            var profileVM = UserProfileVM.FromDto(profileDto);

            return View("Profile",profileVM);
        }


    }
  
}
    

