using Forum.Common.Dtos.Category;

namespace Forum.Bll.Interfaces
{
    public interface ICategoryService
    {
        Task<IList<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        Task<CategoryDto> UpdateCategoryAsync(int id, CategoryUpdateDto categoryUpdateDto);
        Task DeleteCategoryAsync(int id);
    }
}
