using Forum.Dal.Interfaces;
using Forum.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Forum.Dal.Repositories
{
    public class EFCoreRepository<T> : IRepository<T>, IDisposable where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public EFCoreRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
           T entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IList<T>> GetByQueryAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
