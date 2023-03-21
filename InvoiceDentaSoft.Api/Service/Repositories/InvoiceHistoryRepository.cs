using InvoiceDentaSoft.Api.Context;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDentaSoft.Api.Service.Repositories
{
    public class InvoiceHistoryRepository : IInvoiceHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceHistory>> GetAllAsync()
        {
            
            return await _context.InvoiceHistories.ToListAsync();
        }

        public async Task<InvoiceHistory> AddAsync(InvoiceHistory invoiceHistory)
        {
            _context.InvoiceHistories.Add(invoiceHistory);
            await _context.SaveChangesAsync();
            return invoiceHistory;
        }

        public async Task<InvoiceHistory> UpdateInvoiceHistoryAsync(InvoiceHistory invoiceHistory)
        {
            _context.InvoiceHistories.Update(invoiceHistory);
            await _context.SaveChangesAsync();
            return invoiceHistory;
        }

        public async Task<InvoiceHistory> DeleteAsync(InvoiceHistory invoiceHistory)
        {
            _context.InvoiceHistories.Remove(invoiceHistory);
            //category.Enabled = false;
            await _context.SaveChangesAsync();
            return invoiceHistory;

        }

        public async Task<InvoiceHistory?> GetByIdAsync(int categoryId)
        {
            return await _context
                .InvoiceHistories
                .Where(x => x.Id == categoryId).FirstOrDefaultAsync();
        }

        public async Task<bool> InvoiceHistoryExistsAsync(string description)
        {
            return _context
                     .InvoiceHistories
                     .Any(c => c.Description == description);
        }
    }
}
