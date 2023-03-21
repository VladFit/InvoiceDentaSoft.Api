using InvoiceDentaSoft.Api.Context;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDentaSoft.Api.Service.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            //category.Enabled = false;
            await _context.SaveChangesAsync();
            return category;

        }

        public async Task<Category?> GetByIdAsync(int categoryId)
        {
            return await _context
                .Categories
                .Where(x => x.Id == categoryId).FirstOrDefaultAsync();
        }

        public async Task<bool> CategoryExistsAsync(string categoryName)
        {
            return _context
                     .Categories
                     .Any(c => c.Name == categoryName);
        }
    }
}
