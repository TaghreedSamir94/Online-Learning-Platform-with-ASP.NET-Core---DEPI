using SkillUP.DataAccessLayer.Entities;
using SkillUP.DataAccessLayer.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.DataAccessLayer.Repositories.CourseRepositories
{
	public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<List<Course>> GetLastCoursesAsync(int count);
        Task<List<Course>> GetAllCoursesWithInstructorAsync();
        Task<Course> GetDetails(int id);
        Task<List<Course>> SearchCoursesAsync(string searchTerm, float? minPrice, float? maxPrice, int? totalHours);
    }
}
