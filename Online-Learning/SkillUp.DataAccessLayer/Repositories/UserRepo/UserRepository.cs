using Microsoft.EntityFrameworkCore;
using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Entities.UserEntities;
using SkillUp.DataAccessLayer.Repositories.GenericRepositories;
using SkillUp.DataAccessLayer.Repositories.UserRepo;

namespace SkillUp.DataAccessLayer.Repositories
{
    public class UserRepository : GenericRepository<GeneralUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context):base(context)
        {

        }

        public async Task<GeneralUser> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }









    }
}
