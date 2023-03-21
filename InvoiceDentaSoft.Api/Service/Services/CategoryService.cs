using InvoiceDentaSoft.Api.Dto_s.Models.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDentaSoft.Api.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>Get all categories.</summary>
        /// <param name="getRequest">The get request.</param>
        /// <returns>return List of Categories<br /></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        /// <summary>Creates new category.</summary>
        /// <param name="createRequest">The create request.</param>
        /// <returns>return CreateCategoryResponse<br /></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest request)
        {
            //check if category exists by Name
            if (await _categoryRepository.CategoryExistsAsync(request.Name))
            {
                throw new Exception("The category already exists  with such Name!");
            }

            var createdAt = DateTime.UtcNow;

            var category = new Category(
                request.CompanyId,
                request.Name,
                request.Type,
                request.Color,
                request.Enabled,
                createdAt);

            var entity = await _categoryRepository.AddCategoryAsync(category);

            var response = new CreateCategoryResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Type = entity.Type,
                Color = entity.Color,
                Enabled = entity.Enabled,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        /// <summary>Updates the category that exists asynchronous.</summary>
        /// <param name="updateRequest">The update request.</param>
        /// <param name="Id">The temporary category identifier.</param>
        /// <returns>return UpdateCategoryResponse</returns>
        public async Task<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest? updateRequest)
        {
            var category = await _categoryRepository.GetByIdAsync(updateRequest.Id);
            if(category == null)
            {
                throw new Exception("There is no category with such Id!");
            }

            var updatedAt = DateTime.UtcNow;

            category.CompanyId = updateRequest.CompanyId;
            category.Name = updateRequest.Name;
            category.Type = updateRequest.Type;
            category.Color = updateRequest.Color;
            category.Enabled = updateRequest.Enabled;
            category.UpdatedAt = updatedAt;

            var entity = await _categoryRepository.UpdateCategoryAsync(category);

            var response = new UpdateCategoryResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Type = entity.Type,
                Color = entity.Color,
                Enabled = entity.Enabled,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        /// <summary>Deletes the category info and fully removed it asynchronous.</summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>return DeleteCategoryResponse</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new Exception("There is no category with such Id!");
            }

            var entity = await _categoryRepository.DeleteAsync(category);
            
        }

        /// <summary>Check if category exists by Name.</summary>
        /// <param name="Name">The name.</param>
        /// <returns>return bool</returns>`1
        public async Task<bool> CategoryExistsAsync(string name)
        {
            return await _categoryRepository.CategoryExistsAsync(name);
        }
    }
}
