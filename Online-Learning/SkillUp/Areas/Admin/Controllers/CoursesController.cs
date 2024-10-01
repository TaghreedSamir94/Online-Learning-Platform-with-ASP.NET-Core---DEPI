using Microsoft.AspNetCore.Mvc;
using SkillUp.ActionRequests.CoursesRequest;
using SkillUp.BussinessLayer.DTOs.CoursesDTOs;
using SkillUp.BussinessLayer.Services;
using SkillUp.VMs.CoursesVMs;

namespace SkillUp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {


        private readonly ICoursesService _coursesService;
        private readonly IWebHostEnvironment _webHostEnvironment; //for access wwwroot while create

        public CoursesController(ICoursesService coursesService, IWebHostEnvironment webHostEnvironment)
        {
            _coursesService = coursesService;
            _webHostEnvironment = webHostEnvironment;

        }

       #region Get all Data    
		//  .../Admin/Courses/Index
		public async Task<IActionResult> Index()
        {
            
            var coursesDto = await _coursesService.GetAll(); // Fetch DTos from service

            var coursesVMs = coursesDto.Select(c => (CoursesListVMs)c).ToList(); // Convert DTOs to VMs using explicit operator

            return View("CoursesList", coursesVMs);
        }

       #endregion


		#region AddCourse
		//  .../Admin/Courses/Create
		public IActionResult Create()
        { 
            return View("AddCourses");
        }

        [HttpPost,ActionName("Create")]
        public async Task<IActionResult> Create(AddCoursesActionReq request)
        {
            if (!ModelState.IsValid)
            {
				
                return View(request);
            }
   
            var addCoursesDto = request.ToDto();

           // string wwwRootPath = _webHostEnvironment.WebRootPath; ///get wwwrootpath to save image

            await _coursesService.AddCourses(addCoursesDto, request.ImageFile, _webHostEnvironment.WebRootPath);

			TempData["success"] = "Courses Created Successfully";

            return RedirectToAction(nameof(Index));
        }

		#endregion


		#region Edit
		//  .../Admin/Courses/Edit/5
		public async Task<IActionResult> Edit(int id)
        {
			var courseDto = await _coursesService.GetById(id);

			if (courseDto == null)
			{
				return NotFound();
			}
			
			var courseVm = (CoursesDetailsVMs)courseDto; // Use explicit conversion fromD to VM

            return View("EditCourses",courseVm);
        }


		[HttpPost, ActionName("Edit")]
		public async Task<IActionResult> Edit(EditCoursesActionReq request)
		{
			if (!ModelState.IsValid)
			{
				return View(request);  
			}

			var courseDto = (EditCoursesDTO)request;// Use explicit conversion from VM to DTO

            await _coursesService.UpdateCourses(courseDto.ID, courseDto, request.ImageFile, _webHostEnvironment.WebRootPath);

            TempData["success"] = "Course updated successfully!";

            return RedirectToAction("Index");
		}


		#endregion

		#region Delete

		//  .../Admin/Courses/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			var courseDto = await _coursesService.GetById(id);
			if (courseDto == null)
			{
				return NotFound(); 
			}
			var courseVmDelete = (CoursesDetailsVMs)courseDto; ;
			return View("Delete", courseVmDelete);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> Delete(DeleteCoursesActionReq request)
		{
			if (!ModelState.IsValid)
			{
				return View(request);
			}

			string fileLocation = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

			var courseDto = (DeleteCoursesDTO)request; // Convert to DTO
			
			await _coursesService.DeleteCourses(courseDto, fileLocation);

            return RedirectToAction("Index");
		}
	}
	#endregion



}

