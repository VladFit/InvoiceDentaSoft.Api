using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Repositories.Intefaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> AddAsync(Item item);
        Task<Item> UpdateAsync(Item item);
        Task<Item> DeleteAsync(Item item);
        Task<Item?> GetByIdAsync(int itemId);
        Task<bool> ItemExistsAsync(string sku);
    }
}
