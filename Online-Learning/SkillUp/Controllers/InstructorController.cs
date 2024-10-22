using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SkillUP.Controllers
{
	[Authorize(Roles = "Instructor")]
	public class InstructorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
