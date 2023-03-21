using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.Items;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.Items;
using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<CreateItemResponse> CreateItemAsync(CreateItemRequest request);
        Task<UpdateItemResponse> UpdateItemAsync(UpdateItemRequest? updateRequest);
        Task DeleteItemAsync(int itemId);
        Task<bool> ItemExistsAsync(string sku);
    }
}
