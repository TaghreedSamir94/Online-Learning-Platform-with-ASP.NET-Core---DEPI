using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.DataAccessLayer.Repositories.GenericRepositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task<T> DeleteAsync(int id);

		Task SaveAsync();

	}
}
