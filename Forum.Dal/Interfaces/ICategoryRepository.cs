using Forum.Domain;

namespace Forum.Dal.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Task<Category> GetCategoryByIdWithIncludeAsync(int id);
        public Task<IList<Category>> GetAllCategoriesWithIncludeAsync();
    }
}
