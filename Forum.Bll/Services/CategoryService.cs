using AutoMapper;
using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Category;
using Forum.Common.Exeptions;
using Forum.Dal.Interfaces;
using Forum.Domain;

namespace Forum.Bll.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _repository.GetAllCategoriesWithIncludeAsync();

            return _mapper.Map<IList<Category>, IList<CategoryDto>>(categories);
        }
        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetCategoryByIdWithIncludeAsync(id);

            if (category is null)
            {
                throw new NotFoundException("Category isn't exists.");
            }
            return _mapper.Map<Category, CategoryDto>(category);
        }
        public async Task<CategoryDto> CreateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);

            await _repository.CreateAsync(category);
            
            await _repository.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDto>(category);
        }
        public async Task<CategoryDto> UpdateCategoryAsync(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var category = await _repository.GetByIdAsync(id);

            if (category is null)
            {
                throw new NotFoundException("Not Found");
            }
            _mapper.Map(categoryUpdateDto, category);

            await _repository.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDto>(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);

            await _repository.SaveChangesAsync();
        }
    }
}
