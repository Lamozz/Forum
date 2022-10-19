using Forum.Domain;
using System.Linq.Expressions;

namespace Forum.Dal.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetByQueryAsync(Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
    }
}
