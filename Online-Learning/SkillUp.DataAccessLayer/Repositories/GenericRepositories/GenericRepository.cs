using Microsoft.EntityFrameworkCore;
using SkillUP.DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.DataAccessLayer.Repositories.GenericRepositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly ApplicationDbContext _context;
		protected readonly DbSet<T> _dbSet;

		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public async Task<T> AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			await SaveAsync();
			return entity;
		}

		public async Task<T> DeleteAsync(int id)
		{
			T entity = await GetByIdAsync(id);
			if (entity != null)
			{
				_dbSet.Remove(entity);
				await SaveAsync(); // Save changes after deleting
				return entity;
			}
			throw new KeyNotFoundException("Entity not found");

		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.AsNoTracking().ToListAsync(); // AsNoTracking for enhance performance
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		public async Task<T> UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
			await SaveAsync();
			return entity;
		}
	}
}
