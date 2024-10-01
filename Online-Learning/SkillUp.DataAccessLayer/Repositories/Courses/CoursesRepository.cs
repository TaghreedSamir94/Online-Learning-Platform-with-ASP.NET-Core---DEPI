using Microsoft.EntityFrameworkCore;
using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Entities;

namespace SkillUp.DataAccessLayer.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly ApplicationDbContext _db;
        public CoursesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Courses courses)
        {
            await _db.Courses.AddAsync(courses);
        }

        public async Task DeleteAsync(int id)
        {
            var course = await GetCoursesByIDAsync(id); 
            if (course != null)
            {
                _db.Courses.Remove(course); 
            }
            else
            {
                throw new KeyNotFoundException("Course not found");
            }

        }

        public async Task<List<Courses>> GetAllAsync()
        {       
            return await _db.Courses.AsNoTracking().ToListAsync(); // AsNoTracking for enhance performance
        }

		public async Task<List<Courses>> GetLastCoursesAsync(int count)
		{
			return await _db.Courses.OrderByDescending(c => c.ID).Take(count).ToListAsync();
		}

		public async Task<Courses> GetCoursesByIDAsync(int id)
        {
          
            return await _db.Courses.FirstOrDefaultAsync(c => c.ID == id);
            //return await _db.Courses.FindAsync(id);
        }

        public async Task UpdateAsync(Courses courses)
        {
            _db.Courses.Update(courses);
            //await SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {

            await _db.SaveChangesAsync();
        }

       
    }
}
