using Forum.Bll.Interfaces;
using Forum.Common.Dtos.Category;
using Forum.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Forum.Api.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : ApplicationControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IList<CategoryDto>> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            return categories;
        }

        [HttpGet("{id}")]
        public async Task<CategoryDto> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            return category;
        }

        [HttpPost("paginate")]
        public async Task<IActionResult> GetPagedHostel([FromBody] PaginateRequest paginateRequest)
        {
            var paginatedHostels = await _categoryService.GetPaginatedCategoriesAsync(paginateRequest);
            return Ok(paginatedHostels);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryService.CreateCategoryAsync(categoryUpdateDto);

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryService.UpdateCategoryAsync(id, categoryUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);

            return NoContent();
        }
    }
}
