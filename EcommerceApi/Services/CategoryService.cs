using EcommerceApi.Models.Domain;
using EcommerceApi.Repositories;

namespace EcommerceApi.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryByIdAsync(int id);

        Task<int> CreateCategoryAsync(Category category);

        Task<int> UpdateCategoryAsync(Category category);

        Task<bool> DeleteCategoryAsync(int id);
    }
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

        public async Task<int> CreateCategoryAsync(Category category)
        {
            return await _categoryRepository.CreateCategory(category);
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            return await _categoryRepository.UpdateCategory(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _categoryRepository.DeleteCategory(id);
        }
    }
}
