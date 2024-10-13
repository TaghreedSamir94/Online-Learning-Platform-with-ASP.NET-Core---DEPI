using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Repositories.Enrollment
{
    public class ProgressRepository: IProgressRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProgressDTO GetProgressByUserAndCourse(int userId, int courseId)
        {
            var progress = _context.Progresses
                .FirstOrDefault(p => p.UserId == userId && p.CourseId == courseId);

            if (progress == null) return null;

            return new ProgressDTO
            {
                UserId = progress.UserId,
                CourseId = progress.CourseId,
                CompletedModules = progress.CompletedModules,
                LastUpdated = progress.LastUpdated
            };
        }

        public void UpdateProgress(ProgressDTO progressDto)
        {
            var progress = _context.Progresses
                .FirstOrDefault(p => p.UserId == progressDto.UserId && p.CourseId == progressDto.CourseId);

            if (progress != null)
            {
                progress.CompletedModules = progressDto.CompletedModules;
                progress.LastUpdated = progressDto.LastUpdated;
                _context.SaveChanges();
            }
        }

        public void AddProgress(ProgressDTO progressDto)
        {
            var progress = new Progress
            {
                UserId = progressDto.UserId,
                CourseId = progressDto.CourseId,
                CompletedModules = progressDto.CompletedModules,
                LastUpdated = progressDto.LastUpdated
            };

            _context.Progresses.Add(progress);
            _context.SaveChanges();
        }
    }
}
