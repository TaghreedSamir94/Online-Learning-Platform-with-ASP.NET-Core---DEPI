using Microsoft.AspNetCore.Mvc;
using SkillUp.BussinessLayer.DTOs.Progress;
using SkillUp.BussinessLayer.Services.Progress;

namespace SkillUp.Controllers.Progress
{
    public class ProgressController : Controller
    {
        private readonly IProgrssService _progressService;

        public ProgressController(IProgrssService progressService)
        {
            _progressService = progressService;
        }

        // Get progress by userId
        [HttpGet]
        public async Task<IActionResult> GetUserProgress(int userId)
        {
            var result = await _progressService.GetUserProgress(userId);
            if (result.IsSuccess)
            {
                return View(result.Entity); 
            }
            return View("Error", result.Msg); 
        }

        // Update progress for a course
        [HttpPost]
        public async Task<IActionResult> UpdateProgress(ProgressDTO progressDto)
        {
            if (ModelState.IsValid)
            {
                await _progressService.UpdateProgress(progressDto);
                return RedirectToAction("GetUserProgress", new { userId = progressDto.UserId });
            }

            return View(progressDto); 
        }
    }
}
}
