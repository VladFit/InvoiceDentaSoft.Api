using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceItem;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceItem;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDentaSoft.Api.Service.Services
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly IInvoiceItemRepository _invoiceitemRepository;
        private readonly IItemRepository _itemRepository;

        public InvoiceItemService(IInvoiceItemRepository invoiceitemRepository, IItemRepository itemRepository)
        {
            _invoiceitemRepository = invoiceitemRepository;
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<InvoiceItem>> GetAllInvoiceItems()
        {
            return await _invoiceitemRepository.GetAllInvoiceItemsAsync();
        }

        public async Task<CreateInvoiceItemResponse> CreateInvoiceItemAsync(CreateInvoiceItemRequest request)
        {
            //check if category exists by Name
            if (await _invoiceitemRepository.InvoiceItemExistsAsync(request.DiscountType))
            {
                throw new Exception("The invoice item already exists  with such name!");
            }

            var createdAt = DateTime.UtcNow;

            var item = await GetItem(request.ItemId);

            var invoiceitem = new InvoiceItem(
                request.CompanyId,
                request.InvoiceId,
                request.ItemId,
                item.Name,
                item.Sku,
                item.Quantity,
                item.SalePrice,
                request.Total,
                request.Tax,
                request.DiscountRate,
                request.DiscountType,
                createdAt);

            var entity = await _invoiceitemRepository.AddInvoiceItemAsync(invoiceitem);

            var response = new CreateInvoiceItemResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                InvoiceId = entity.InvoiceId,
                ItemId = entity.ItemId,
                Name = entity.Name,
                Sku = entity.Sku,
                Quantity = entity.Quantity,
                Price = entity.Price,
                Total = entity.Total,
                Tax = entity.Tax,
                DiscountRate = entity.DiscountRate,
                DiscountType = entity.DiscountType,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };
            return response;
        }

        public async Task<UpdateInvoiceItemResponse> UpdateInvoiceItemAsync(UpdateInvoiceItemRequest? updateRequest)
        {
            var invoiceitem = await _invoiceitemRepository.GetByIdAsync(updateRequest.Id);
            if (invoiceitem == null)
            {
                throw new Exception("There is no invoice item with such Id!");
            }

            var updatedAt = DateTime.UtcNow;

            var item = await GetItem(updateRequest.ItemId);

            invoiceitem.CompanyId = updateRequest.CompanyId;
            invoiceitem.InvoiceId = updateRequest.InvoiceId;
            invoiceitem.ItemId = updateRequest.ItemId;
            invoiceitem.Name = item.Name;
            invoiceitem.Sku = item.Sku;
            invoiceitem.Quantity = item.Quantity;
            invoiceitem.Price = item.SalePrice;
            invoiceitem.Total = updateRequest.Total;
            invoiceitem.Tax = updateRequest.Tax;
            invoiceitem.DiscountRate = updateRequest.DiscountRate;
            invoiceitem.DiscountType = updateRequest.DiscountType;
            invoiceitem.UpdatedAt = updatedAt;

            var entity = await _invoiceitemRepository.UpdateInvoiceItemAsync(invoiceitem);

            var response = new UpdateInvoiceItemResponse()
            {
                Id = entity.Id,
                CompanyId= entity.CompanyId,
                InvoiceId= entity.InvoiceId,
                ItemId= entity.ItemId,
                Name= entity.Name,
                Sku= entity.Sku,
                Quantity= entity.Quantity,
                Price= entity.Price,
                Total= entity.Total,
                Tax= entity.Tax,
                DiscountRate= entity.DiscountRate,
                DiscountType= entity.DiscountType,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task DeleteInvoiceItemAsync(int invoiceitemId)
        {
            var invoiceitem = await _invoiceitemRepository.GetByIdAsync(invoiceitemId);
            if (invoiceitem == null)
            {
                throw new Exception("There is no invoice item with such Id!");
            }

            var entity = await _invoiceitemRepository.DeleteAsync(invoiceitem);

        }

        public async Task<bool> InvoiceItemExistsAsync(string name)
        {
            return await _invoiceitemRepository.InvoiceItemExistsAsync(name);
        }

        public async Task<Item> GetItem(int? itemId)
        {
            var entity = await _itemRepository.GetByIdAsync((int)itemId);

            if (entity == null)
            {
                throw new Exception("There is no item type with such Id!!");
            }
            return entity;
        }
    }
}
