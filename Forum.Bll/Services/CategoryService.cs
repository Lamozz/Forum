using AutoMapper;
using Forum.Common.Exeptions;
using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Category;
using Forum.Dal.Interfaces;
using Forum.Domain;

namespace Forum.Bll.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _repository.GetAllAsync();
            return categories.Select(categories => _mapper.Map<Category, CategoryDto>(categories)).ToList();
        }
        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);

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

            await _repository.UpdateAsync(category);

            return _mapper.Map<Category, CategoryDto>(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}
