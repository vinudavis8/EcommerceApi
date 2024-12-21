using EcommerceApi.Data;
using EcommerceApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repositories
{

    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetCategoryById(int id);
        Task<int> CreateCategory(Category category);
        Task<int> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int id);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            Category category = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            Category category = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            return category;

        }

        public async Task<int> UpdateCategory(Category category)
        {
            var existingCategory = _context.Categories.Where(x => x.Id == category.Id).FirstOrDefault();
            if (existingCategory == null)
            {
                return 0;
            }
            existingCategory.Description = category.Description;
            existingCategory.Name = category.Name;
            existingCategory.ImageUrl = category.ImageUrl;
            await _context.SaveChangesAsync();
            return existingCategory.Id;
        }
    }
}
