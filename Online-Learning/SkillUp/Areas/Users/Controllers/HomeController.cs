using Microsoft.AspNetCore.Mvc;
using SkillUp.ActionRequests.CoursesRequest;
using SkillUp.BussinessLayer.Services;
using SkillUp.VMs;
using SkillUp.VMs.CoursesVMs;
using System.Diagnostics;

namespace SkillUp.Areas.Users.Controllers
{
    [Area("Users")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICoursesService _coursesServ;

        public HomeController(ILogger<HomeController> logger, ICoursesService coursesServ)
        {
            _logger = logger;
            _coursesServ = coursesServ;

        }


        public async Task<IActionResult> Index()
        {
            var newCoursesDto = await _coursesServ.GetLastCourses(4);

            var newCourses = newCoursesDto.Select(dto => (HomeCoursesVMs)dto).ToList();

            ViewBag.TrendingCourses = newCourses;

            return View();
        }


        public async Task<IActionResult>TrendingCourses(int count = 4)
        {
            var newCoursesDto = await _coursesServ.GetLastCourses(count);
            var newCourses = newCoursesDto.Select(dto => (HomeCoursesVMs)dto).ToList();

            return PartialView("HomeCoursesSection", newCourses);
        }


        public async Task<IActionResult> GetAllCourses()
        {
            var coursesDto = await _coursesServ.GetAll();

            var coursesVMs = coursesDto.Select(c => (CoursesListVMs)c).ToList();

            return View("AllCourses", coursesVMs);
        }


        public async Task<IActionResult>GetCourseById(int id)
        {
            var courseDto = await _coursesServ.GetById(id);

            if (courseDto == null)
            {
                return NotFound("Course not found.");
            }

            var courseVm = (CoursesDetailsVMs)courseDto;  // Use explicit conversion

            return View("CourseDetails", courseVm);

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
