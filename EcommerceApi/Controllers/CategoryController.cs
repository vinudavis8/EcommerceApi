using EcommerceApi.Models.Domain;
using EcommerceApi.Models.DTO;
using EcommerceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _service;
        public CategoryController(ICategoryService service)
        {

            _service = service;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _service.GetAllCategoriesAsync();

        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<Category> GetCategoryById(int id)
        {
            return await _service.GetCategoryByIdAsync(id);
        }

        [HttpPost]
        public async Task<int> CreateCategory([FromBody] CategoryCreateRequestDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                ImageUrl = categoryDto.ImageUrl,              
            };
            return await _service.CreateCategoryAsync(category);
        }

        [HttpPut]
        public async Task<int> UpdateCategory([FromBody] UpdateCategoryRequestDto categoryDto)
        {
            var category = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                ImageUrl = categoryDto.ImageUrl,
            };
            return await _service.UpdateCategoryAsync(category);
        }

        [HttpDelete]
        public async Task<bool> DeleteCategory(int id)
        {
            return await _service.DeleteCategoryAsync(id);
        }
    }
}
