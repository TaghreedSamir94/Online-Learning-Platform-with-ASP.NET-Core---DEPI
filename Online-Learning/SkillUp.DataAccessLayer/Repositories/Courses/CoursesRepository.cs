using Microsoft.EntityFrameworkCore;
using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Repositories.GenericRepositories;

namespace SkillUp.DataAccessLayer.Repositories
{
    public class CoursesRepository : GenericRepository<Courses>, ICoursesRepository
    {
       
        public CoursesRepository(ApplicationDbContext db) : base(db)
        { 
        }

        public async Task<List<Courses>> GetLastCoursesAsync(int count)
        {
            return await _dbSet.OrderByDescending(c => c.ID).Take(count).ToListAsync();
        }
    
    }
}
