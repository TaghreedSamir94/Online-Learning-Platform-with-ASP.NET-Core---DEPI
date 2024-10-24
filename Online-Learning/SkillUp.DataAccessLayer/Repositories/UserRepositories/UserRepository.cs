using Microsoft.EntityFrameworkCore;
using SkillUP.DataAccessLayer.Data;
using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.DataAccessLayer.Repositories.GenericRepositories;
using System;

namespace SkillUP.DataAccessLayer.Repositories.UserRepositories
{
	public class UserRepository : GenericRepository<GeneralUser>, IUserRepository
	{
		public UserRepository(ApplicationDbContext context) : base(context) { }
		public async Task<GeneralUser> GetByEmailAsync(string email)
		{
			return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<GeneralUser> GetStudProfileByIdAsync(string userId)
        {
            return await _dbSet.Include(u => (u as Student).Enrollments)  .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<List<GeneralUser>> SearchUserByName(string name)
        {
            return await _dbSet.Where(u => u.UserName.Trim().ToLower().Contains(name.Trim().ToLower())).ToListAsync();
        }


    }
}
