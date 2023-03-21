using InvoiceDentaSoft.Api.Context;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDentaSoft.Api.Service.Repositories
{
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceItem>> GetAllInvoiceItemsAsync()
        {

            return await _context.InvoiceItems.ToListAsync();
        }

        public async Task<InvoiceItem> AddInvoiceItemAsync(InvoiceItem invoiceitem)
        {
            _context.InvoiceItems.Add(invoiceitem);
            await _context.SaveChangesAsync();
            return invoiceitem;
        }

        public async Task<InvoiceItem> UpdateInvoiceItemAsync(InvoiceItem invoiceitem)
        {
            _context.InvoiceItems.Update(invoiceitem);
            await _context.SaveChangesAsync();
            return invoiceitem;
        }

        public async Task<InvoiceItem> DeleteAsync(InvoiceItem invoiceitem)
        {
            //var clinic = await GetByIdAsync(tempClinicId);

            //if (clinic is null)
            //{
            //    throw new Exception(DentaSoftApiDisplayMessages.ClinicNotFound);
            //}

            _context.InvoiceItems.Remove(invoiceitem);
            //category.Enabled = false;
            await _context.SaveChangesAsync();
            return invoiceitem;

        }

        public async Task<InvoiceItem?> GetByIdAsync(int invoiceitemId)
        {
            return await _context
                .InvoiceItems
                .Where(x => x.Id == invoiceitemId).FirstOrDefaultAsync();
        }

        public async Task<bool> InvoiceItemExistsAsync(string sku)
        {
            return _context
                     .InvoiceItems
                     .Any(c => c.Name == sku);
        }
    }
}
