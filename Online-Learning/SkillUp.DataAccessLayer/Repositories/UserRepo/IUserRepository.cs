using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Repositories.GenericRepositories;


namespace SkillUp.DataAccessLayer.Repositories.UserRepo
{
    public interface IUserRepository : IGenericRepository<GeneralUser>
    {
        //Task<GeneralUser> GetByUsernameAsync(string username);
        Task<GeneralUser> GetByEmailAsync(string email);

    }
}
