using Microsoft.EntityFrameworkCore;
using SkillUp.DataAccessLayer.Data;
using SkillUp.DataAccessLayer.Entities;

namespace SkillUp.DataAccessLayer.Repositories.GenericRepositories
{

        public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            protected readonly ApplicationDbContext context;

            private readonly DbSet<T> _dbSet;
            public GenericRepository(ApplicationDbContext _context)
            {
                context = _context;
                _dbSet = this.context.Set<T>();

            }
            public async Task<T> AddAsync(T t)
            {
                var adding = await _dbSet.AddAsync(t);

                return adding.Entity;
            }

            public async Task<T> DeleteAsync(int id)
            {
                var result = await GetByIdAsync(id);
                if (result == null)
                {
                    return null;

                }
                else
                {
                    var deleting = _dbSet.Remove(result);

                    return deleting.Entity;
                }
            }

            public async Task<List<T>> GetAllAsync()
            {
                return await _dbSet.ToListAsync(); // convert data table to list
            }

            public async Task<T> GetByIdAsync(int id)
            {
                return await _dbSet.FindAsync(id);
            }

            public async Task<int> SaveAsync()
            {
                return await context.SaveChangesAsync();
            }

            public async Task<T> UpdateAsync(T t)
            {
                var updating = _dbSet.Update(t);
                await SaveAsync();
                return updating.Entity;
            }
        }
    }


