using Microsoft.EntityFrameworkCore;
using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp.DataAccessLayer.Repositories.Progress
{
    public class ProgressRepository : GenericRepository<Entities.Progress>, IProgressRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Entities.Progress> GetProgressByUserId(int userId)
        {
            return _context.Progresses
                .Where(p => p.UserId == userId)
                .Include(p => p.Course)
                .ToList();
        }

        // Add progress
        public void AddProgress(Entities.Progress progress)
        {
            progress.LastUpdated = DateTime.Now;
            _context.Progresses.Add(progress);
            _context.SaveChanges();
        }

        // Update progress
        public void UpdateProgress(Entities.Progress progress)
        {
            var existingProgress = _context.Progresses
                .FirstOrDefault(p => p.ProgressId == progress.ProgressId);

            if (existingProgress != null)
            {
                existingProgress.CompletionPercentage = progress.CompletionPercentage;
                existingProgress.LastUpdated = DateTime.Now;
                existingProgress.CourseId = progress.CourseId;

                _context.Progresses.Update(existingProgress);
                _context.SaveChanges();
            }

        }
    }
}
