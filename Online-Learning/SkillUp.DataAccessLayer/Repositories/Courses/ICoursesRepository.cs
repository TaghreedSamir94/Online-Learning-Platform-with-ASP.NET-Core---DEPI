using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Repositories;
using SkillUp.DataAccessLayer.Repositories.GenericRepositories;

namespace SkillUp.DataAccessLayer
{
    public interface ICoursesRepository : IGenericRepository<Courses>
    {
        Task<List<Courses>> GetLastCoursesAsync(int count); // to display new courses on the homepage
    }
}