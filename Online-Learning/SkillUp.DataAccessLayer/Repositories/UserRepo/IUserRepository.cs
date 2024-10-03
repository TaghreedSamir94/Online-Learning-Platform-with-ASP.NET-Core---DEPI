using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Repositories.GenericRepositories;


namespace SkillUp.DataAccessLayer.Repositories.UserRepo
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);

    }
}
