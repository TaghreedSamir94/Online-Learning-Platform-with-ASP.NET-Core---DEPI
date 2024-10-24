using Microsoft.EntityFrameworkCore;
using SkillUP.DataAccessLayer.Data;
using SkillUP.DataAccessLayer.Entities;
using SkillUP.DataAccessLayer.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.DataAccessLayer.Repositories.CourseRepositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Course>> SearchCoursesAsync(string searchTerm, float? minPrice, float? maxPrice, int? totalHours)
        {
            var query = _context.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(c => c.Title.Contains(searchTerm) || c.Instructor.FullName.Contains(searchTerm));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(c => c.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(c => c.Price <= maxPrice.Value);
            }
            if (totalHours.HasValue)
            {
                query = query.Where(c => c.TotalHours <= totalHours.Value);

            }

            return query.ToList();
        }

        public async Task<List<Course>> GetAllCoursesWithInstructorAsync()
        {
            return await _dbSet.Include(c => c.Instructor).ToListAsync();
        }

        public async Task<List<Course>> GetLastCoursesAsync(int count)
        {
            return await _context.Courses.Include(c => c.Instructor).OrderByDescending(c => c.Id).Take(count).ToListAsync();
        }

        public async Task <Course> GetDetails(int id)
        {
            return await _context.Courses.Include(c => c.Instructor) .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
