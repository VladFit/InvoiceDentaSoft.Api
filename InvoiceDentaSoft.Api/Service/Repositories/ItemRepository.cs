using InvoiceDentaSoft.Api.Context;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDentaSoft.Api.Service.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> AddAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> UpdateAsync(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> DeleteAsync(Item item)
        {
            _context.Items.Remove(item);
            //category.Enabled = false;
            await _context.SaveChangesAsync();
            return item;

        }

        public async Task<Item?> GetByIdAsync(int itemId)
        {
            return await _context
                .Items
                .Where(x => x.Id == itemId).FirstOrDefaultAsync();
        }

        public async Task<bool> ItemExistsAsync(string sku)
        {
            return _context.Items.Any(c => c.Sku == sku);
        }
    }
}
