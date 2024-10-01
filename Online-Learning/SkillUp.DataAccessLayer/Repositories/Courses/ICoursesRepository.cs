
using SkillUp.DataAccessLayer.Entities;

namespace SkillUp.DataAccessLayer.Repositories
{
    public interface ICoursesRepository
    {
        Task<List<Courses>> GetAllAsync();

		Task<List<Courses>> GetLastCoursesAsync(int count); //to display new courses in home page

		Task<Courses> GetCoursesByIDAsync(int id);

        Task AddAsync(Courses courses);

        Task UpdateAsync(Courses courses);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();


    }
}
