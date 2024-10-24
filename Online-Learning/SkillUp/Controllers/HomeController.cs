using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillUP.BusinessLayer.Services.AdminCourseMangerServices;
using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.Models;
using SkillUP.VMs.AdminDashboardVMs.MangerCoursesVMs;
using System.Diagnostics;

namespace SkillUP.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICourseServices _coursesServ;
        private readonly UserManager<GeneralUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ICourseServices coursesServ, UserManager<GeneralUser> userManager)
		{
			_logger = logger;
			_coursesServ = coursesServ;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var newCoursesDto = await _coursesServ.GetLastCourses(4);

			var newCourses = newCoursesDto.Select(dto => (NewCoursesVM)dto).ToList();

			ViewBag.TrendingCourses = newCourses;

			return View();
		}

        public async Task<IActionResult> TrendingCourses(int count = 4)
        {
            var newCoursesDto = await _coursesServ.GetLastCourses(count);
            var newCourses = newCoursesDto.Select(dto => (NewCoursesVM)dto).ToList();

            return PartialView("HomeCoursesSection", newCourses);
        }

		public async Task<IActionResult> GetAllCourses()
		{
			var courseListDto = await _coursesServ.GetAll();
            var courseListVm = courseListDto.Select(c => (CourseListVM)c).ToList();
            return View("AllCoursesPage", courseListVm);
		}

		public async Task<IActionResult> GetCourseDetails(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            
            var studentId = user.Id;

            var courseDetailsDto = await _coursesServ.GetCourseByIdWithStudent(id, studentId);
            if (courseDetailsDto == null)
            {
                return NotFound("Course not found.");
            }
			var courseDetailsVm = CourseDetailsVM.FromDto(courseDetailsDto);
            return View("CourseDetailsPage", courseDetailsVm);
		}


        public async Task<IActionResult> Search(string searchTerm, float? minPrice, float? maxPrice, int? totalHours)
        {
            if (!string.IsNullOrEmpty(searchTerm) || minPrice.HasValue || maxPrice.HasValue || totalHours.HasValue)
            {
                var courses = await _coursesServ.SearchCoursesAsync(searchTerm, minPrice, maxPrice, totalHours);

                // Use the explicit conversion operator to map DTO to VM
                var coursesListVM = courses.Select(c => (CourseListVM)c).ToList();

                ViewBag.SearchTerm = searchTerm;
                ViewBag.MinPrice = minPrice;
                ViewBag.MaxPrice = maxPrice;
                ViewBag.TotalHours = totalHours;

                return View("AllCoursesPage", coursesListVM);
            }
            else
            {
                var allCourses = await _coursesServ.GetAll();

                // Use the explicit conversion operator to map DTO to VM
                var coursesListVM = allCourses.Select(c => (CourseListVM)c).ToList();

                return View("AllCoursesPage", coursesListVM);
            }
        }



        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
