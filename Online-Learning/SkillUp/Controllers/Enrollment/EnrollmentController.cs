using Microsoft.AspNetCore.Mvc;
using SkillUp.BussinessLayer.DTOs.EnrollmentDTOs;
using SkillUp.BussinessLayer.Services.Enrollment;

namespace SkillUp.Controllers.Enrollment
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        // GET: Enrollment
        public async Task<IActionResult> Index()
        {
            var enrollments = await _enrollmentService.GetAllAsync();
            return View(enrollments);
        }

        // GET: Enrollment/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var enrollment = await _enrollmentService.GetByIDAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GetEnrollmentDTO enrollmentDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _enrollmentService.CreateAsync(enrollmentDTO);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Msg); 
            }
            return View(enrollmentDTO);
        }

        // GET: Enrollment/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var enrollment = await _enrollmentService.GetByIDAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GetEnrollmentDTO enrollmentDTO)
        {
            if (id != enrollmentDTO.Id)
            {
                return BadRequest("Enrollment ID mismatch.");
            }

            if (ModelState.IsValid)
            {
                var result = await _enrollmentService.UpdateAsync(enrollmentDTO);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Msg); 
            }
            return View(enrollmentDTO);
        }

        // GET: Enrollment/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var enrollment = await _enrollmentService.GetByIDAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var existingEnrollment = await _enrollmentService.GetByIDAsync(id);
            if (existingEnrollment == null)
            {
                return NotFound();
            }

            await _enrollmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

