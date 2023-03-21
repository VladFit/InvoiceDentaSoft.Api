using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Repositories.Intefaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<Category> DeleteAsync(Category category);
        Task<Category?> GetByIdAsync(int categoryId);
        Task<bool> CategoryExistsAsync(string categoryName);
    }
}
