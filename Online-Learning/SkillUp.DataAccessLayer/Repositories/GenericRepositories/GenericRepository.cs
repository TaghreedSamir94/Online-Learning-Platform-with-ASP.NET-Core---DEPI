using Microsoft.EntityFrameworkCore;
using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Entities;

namespace SkillUp.DataAccessLayer.Repositories.GenericRepositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();// Initialize _dbSet with the appropriate entity set
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync(); // AsNoTracking for enhance performance
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync(); 
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
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

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

      
    }
}


