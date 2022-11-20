using Forum.Dal.Interfaces;
using Forum.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Forum.Dal.Repositories
{
    public class EFCoreRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public EFCoreRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
           T entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
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

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
