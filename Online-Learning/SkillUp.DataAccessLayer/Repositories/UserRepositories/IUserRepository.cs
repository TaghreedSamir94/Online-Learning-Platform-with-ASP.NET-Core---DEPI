using SkillUP.DataAccessLayer.Entities.Users;
using SkillUP.DataAccessLayer.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.DataAccessLayer.Repositories.UserRepositories
{
	public interface IUserRepository : IGenericRepository<GeneralUser>
	{
		Task<GeneralUser> GetByEmailAsync(string email);
		Task<GeneralUser> GetStudProfileByIdAsync(string userId);
        Task<List<GeneralUser>> SearchUserByName(string name);


    }
}
