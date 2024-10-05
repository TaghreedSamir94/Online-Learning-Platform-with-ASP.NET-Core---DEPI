using Microsoft.EntityFrameworkCore;
using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Entities;
using SkillUp.DataAccessLayer.Repositories.GenericRepositories;
using SkillUp.DataAccessLayer.Repositories.UserRepo;

namespace SkillUp.DataAccessLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(ApplicationDbContext context):base(context)
        {

        }
        public async Task<User> AddAsync(User t)
        {
            var addedUser = await _dbSet.AddAsync(t);
            await SaveAsync();

            return addedUser.Entity;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
                return null;

            _dbSet.Remove(user);
            await SaveAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateAsync(User t)
        {
            _dbSet.Update(t);
            await SaveAsync();
            return t;
        }

   
      

     
    }
}
