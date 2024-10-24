using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUP.ActionRequests.AdminDashboardActionReq.MangerCoursesActionReq;
using SkillUP.ActionRequests.AdminDashboardActionReq.MangerUserActionReq;
using SkillUP.BusinessLayer.Services.AdminCourseMangerServices;
using SkillUP.BusinessLayer.Services.AdminUserMangerServices;
using SkillUP.VMs.AdminDashboardVMs.MangerCoursesVMs;
using SkillUP.VMs.AdminDashboardVMs.MangerUserVMs;
using SkillUP.BusinessLayer.DTOs.AdminDashboardDTOs.ManageUsersDTOs;

namespace SkillUP.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    public class AdminDashboardController : Controller
	{
		private readonly IUserMangerService _userMangerService;
		private readonly ICourseServices _courseService;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public AdminDashboardController(IUserMangerService userMangerService, ICourseServices courseService, IWebHostEnvironment webHostEnvironment)
		{
			_userMangerService = userMangerService;
			_courseService = courseService;
			_webHostEnvironment = webHostEnvironment;
		}



		#region Mange Users

		#region GetAllUsers
		public async Task<IActionResult> Index(string searchValue = "")
        {
            IEnumerable<UserListDTO> users = null;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                users = await _userMangerService.GetAllUsersAsync();
            }
            else if (!string.IsNullOrEmpty(searchValue))
            {
                users = await _userMangerService.SearchUsersByNameAsync(searchValue);
            }
            //var users = await _userMangerService.GetAllUsersAsync();

            // Use explicit operator to map each UserListDTO to UserListVM
            var userVMs = users.Select(u => (UserListVM)u).ToList();

            return View("AllUsers", userVMs);
        }
        #endregion

        #region AddUser
        public IActionResult AddUser()
        {
            return View("AddUser");
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserActionReq addUserRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(addUserRequest);
            }

            try
            {
                var addUserVM = AddUserVM.FromActionRequest(addUserRequest);

                var addUserDTO = (AddUserDTO)addUserVM;

                await _userMangerService.AddUserAsync(addUserDTO);
                
                TempData["success"] = "User added successfully";
              

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(addUserRequest);
            }
        }

        #endregion

        #region EditUser
        public async Task<IActionResult> EditUser(string email)
        {
            var userDetailsDto = await _userMangerService.GetUserByEmailAsync(email);
            if (userDetailsDto == null)
            {
                return NotFound();
            }
            // Use the mapping function
            var editUserVM = EditUserVM.FromDTO(userDetailsDto);
            return View("EditUser", editUserVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserActionReq editUserRequest)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Or log the error
                }
                var editUserVM = EditUserVM.FromActionRequest(editUserRequest);
                return View(editUserVM);
            }

            try
            {
                // Map EditUserActionRequest to EditUserVM
                var editUserVM = EditUserVM.FromActionRequest(editUserRequest);

                //var editUserDto = (EditUserDTO)editUserVM;
                var editUserDto = EditUserVM.ToDTO(editUserVM);

                await _userMangerService.UpdateUserAsync(editUserDto);
                TempData["success"] = "User Updated successfully";
               
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var editUserVM = EditUserVM.FromActionRequest(editUserRequest);
                return View(editUserVM);



            }

        }
        #endregion

        #region DeleteUser


        public async Task<IActionResult> DeleteUser(string email)
        {
            var user = await _userMangerService.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            var deleteUserVM = DeleteUserVM.FromUserDTO(user);
            return View("DeleteUser", deleteUserVM);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(DeleteUserActionReq deleteUserRequest)
        {
            var deleteUserVM = DeleteUserVM.FromActionReq(deleteUserRequest);
            if (!ModelState.IsValid)
            {
                return View(deleteUserVM);
            }

            try
            {
                await _userMangerService.DeleteUserAsync(deleteUserRequest.Email);
                TempData["success"] = "User Deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(deleteUserVM);
            }
        }


		#endregion

		#endregion




		#region Manage courses

		#region Add Courses
		public async Task<IActionResult> AddCourse()
        
        {
            var instructorDtos = await _userMangerService.GetAllInstructorsAsync();
            var model = new AddCourseVM
            {
                Instructor = instructorDtos.Select(InstructorVM.MapFromDto).ToList()
            };
            return View("AddCourse", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(AddCourseActionReq request)
        {
			
			if (!ModelState.IsValid)
            {
				var errors = ModelState.Values.SelectMany(v => v.Errors);
				foreach (var error in errors)
				{
					Console.WriteLine(error.ErrorMessage); // Log errors to the console
				}
				var model = AddCourseVM.FromActionRequest(request);
				return View(model);

            }
            var addCoursesDto = request.ToDto();

            await _courseService.AddCourses(addCoursesDto, request.ImageFile, _webHostEnvironment.WebRootPath);
            TempData["success"] = "Course Added successfully";
            return RedirectToAction("GetAllCourses");

          
        }
		#endregion

		#region GetAllCourses
		public async Task<IActionResult> GetAllCourses()
		{
			var courses = await _courseService.GetAll();
            var coursesVm = courses.Select(dto => (CourseListVM)dto).ToList();
			return View("CoursesList", coursesVm); 
		}
        #endregion

        #region EditCourse
        public async Task<IActionResult> Edit(int id) 
        {
            var courseDetailsDto = await _courseService.GetById(id);
            if (courseDetailsDto == null)
            {
                return NotFound();
            }
            var instructorDtos = await _userMangerService.GetAllInstructorsAsync();
            var courseDetailsVm = CourseDetailsVM.FromDto(courseDetailsDto);
            var model = EditCourseVM.FromCourseDetails(courseDetailsVm, instructorDtos);

            return View("EditCourse", model);
        }
        [HttpPost]
        public async Task<IActionResult> EditCourse(EditCourseActionReq editCourseReq)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Log errors to the console
                }
                var model = EditCourseVM.FromActionRequest(editCourseReq);
                return View(model);
            }

            var courseDto = editCourseReq.ToDto();
            await _courseService.UpdateCourses(courseDto.Id, courseDto, editCourseReq.ImageFile, _webHostEnvironment.WebRootPath);
            TempData["success"] = "Course Updated successfully";
            return RedirectToAction("GetAllCourses");

        }

		#endregion

		#region DeleteCourse
		public async Task<IActionResult> Delete(int id)
		{
			var courseDTO = await _courseService.GetById(id); 

			if (courseDTO == null)
			{
				return NotFound($"Course with ID {id} not found.");
			}
			var instructorDtos = await _userMangerService.GetAllInstructorsAsync();
			var deleteCourseVM = DeleteCourseVM.FromDto(courseDTO, instructorDtos);
			ViewData["IsDeleteMode"] = true;
			return View("DeleteCourse", deleteCourseVM);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteCourse(DeleteCourseActionReq deleteRequest)
		{
		
			if (!ModelState.IsValid)
			{
				var courseDTO = await _courseService.GetById(deleteRequest.Id);

				if (courseDTO == null)
				{
					return NotFound($"Course with ID {deleteRequest.Id} not found.");
				}

				var instructorDtos = await _userMangerService.GetAllInstructorsAsync();
				var deleteCourseVM = DeleteCourseVM.FromDto(courseDTO, instructorDtos);

				return View("DeleteCourse", deleteCourseVM);
			}

			var deleteDto = deleteRequest.ToDto();
			string fileLocation = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
			await _courseService.DeleteCourses(deleteDto, fileLocation);
            TempData["success"] = "Course Deleted successfully";
            return RedirectToAction("GetAllCourses");

		}


		#endregion

		#endregion

	}
}
