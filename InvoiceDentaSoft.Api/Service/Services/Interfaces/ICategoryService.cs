using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest request);
        Task<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest? updateRequest);
        Task DeleteCategoryAsync(int categoryId);
        Task<bool> CategoryExistsAsync(string name);
    }
}
