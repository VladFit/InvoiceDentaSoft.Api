using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.Items;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.Items;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDentaSoft.Api.Service.Services
{
    public class ItemService : IItemService
    {

        private readonly IItemRepository _repose;

        public ItemService(IItemRepository repose)
        {
            _repose = repose;
        }

        /// <summary>Get all items.</summary>
        /// <param name="getRequest">The get request.</param>
        /// <returns>return List of Items<br /></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _repose.GetAllAsync();
        }

        /// <summary>Creates new item.</summary>
        /// <param name="createRequest">The create request.</param>
        /// <returns>return CreateItemResponse<br /></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CreateItemResponse> CreateItemAsync(CreateItemRequest request)
        {
            //check if category exists by Name
            if (await _repose.ItemExistsAsync(request.Sku))
            {
                throw new Exception("The item already exists with such Sku");
            }

            var createdAt = DateTime.UtcNow;

            var item = new Item(
                request.CompanyId,
                request.Name,
                request.Sku,
                request.Description,
                request.SalePrice,
                request.PurchasePrice,
                request.Quantity,
                request.CategoryId,
                request.TaxId,
                request.Enabled,
                createdAt);

            var entity = await _repose.AddAsync(item);

            var response = new CreateItemResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Sku = entity.Sku,
                Description = entity.Description,
                SalePrice = entity.SalePrice,
                PurchasePrice = entity.PurchasePrice,
                Quantity = entity.Quantity,
                CategoryId = entity.CategoryId,
                TaxId = entity.TaxId,
                Enabled = entity.Enabled,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        /// <summary>Updates the item that exists asynchronous.</summary>
        /// <param name="updateRequest">The update request.</param>
        /// <param name="Id">The temporary item identifier.</param>
        /// <returns>return UpdateItemResponse</returns>
        public async Task<UpdateItemResponse> UpdateItemAsync(UpdateItemRequest? updateRequest)
        {
            var item = await _repose.GetByIdAsync(updateRequest.Id);
            if (item == null)
            {
                throw new Exception("There is no item with such Id!");
            }

            var updatedAt = DateTime.UtcNow;

            item.CompanyId = updateRequest.CompanyId;
            item.Name = updateRequest.Name;
            item.Sku = updateRequest.Sku;
            item.Description = updateRequest.Description;
            item.SalePrice = updateRequest.SalePrice;
            item.PurchasePrice = updateRequest.PurchasePrice;
            item.Quantity = updateRequest.Quantity;
            item.CategoryId = updateRequest.CategoryId;
            item.Enabled = updateRequest.Enabled;
            item.UpdatedAt = updatedAt;

            var entity = await _repose.UpdateAsync(item);

            var response = new UpdateItemResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Sku = entity.Sku,
                Description = entity.Description,
                SalePrice = entity.SalePrice,
                PurchasePrice = entity.PurchasePrice,
                Quantity = entity.Quantity,
                CategoryId = entity.CategoryId,
                Enabled = entity.Enabled,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        /// <summary>Deletes the item info and fully removed it asynchronous.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>return DeleteItemResponse</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task DeleteItemAsync(int itemId)
        {
            var item = await _repose.GetByIdAsync(itemId);
            if (item == null)
            {
                throw new Exception("There is no item with such Id!");
            }

            var entity = await _repose.DeleteAsync(item);

        }

        /// <summary>Check if item exists by Sku.</summary>
        /// <param name="Sku">The sku.</param>
        /// <returns>return bool</returns>`1
        public async Task<bool> ItemExistsAsync(string sku)
        {
            return await _repose.ItemExistsAsync(sku);
        }
    }
}
