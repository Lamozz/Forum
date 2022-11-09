using Forum.Dal.Interfaces;
using Forum.Domain;
using Microsoft.EntityFrameworkCore;

namespace Forum.Dal.Repositories
{
    public class CategoryRepository : EFCoreRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByIdWithIncludeAsync(int id)
        {
            var query = IncludeAll();
            return await query.FirstOrDefaultAsync(category => category.Id == id);
        }

        public async Task<IList<Category>> GetAllCategoriesWithIncludeAsync()
        {
            var query = IncludeAll();
            return await query.ToListAsync();
        }

        public IQueryable<Category> IncludeAll()
        {
            return _dbSet
                .Include(category => category.Sections)
                .ThenInclude(section => section.Themes)
                .ThenInclude(theme => theme.Messages)
                .ThenInclude(message => message.Author);
            
        }
    }
}
