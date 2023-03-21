using InvoiceDentaSoft.Api.Context;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDentaSoft.Api.Service.Repositories
{
    public class InvoiceTotalRepository : IInvoiceTotalRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceTotalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceTotal>> GetAllInvoiceTotalsAsync()
        {

            return await _context.InvoiceTotals.ToListAsync();
        }

        public async Task<InvoiceTotal> AddInvoiceTotalAsync(InvoiceTotal invoicetotal)
        {
            _context.InvoiceTotals.Add(invoicetotal);
            await _context.SaveChangesAsync();
            return invoicetotal;
        }

        public async Task<InvoiceTotal> UpdateInvoiceTotalAsync(InvoiceTotal invoicetotal)
        {
            _context.InvoiceTotals.Update(invoicetotal);
            await _context.SaveChangesAsync();
            return invoicetotal;
        }

        public async Task<InvoiceTotal> DeleteAsync(InvoiceTotal invoicetotal)
        {
            _context.InvoiceTotals.Remove(invoicetotal);
            await _context.SaveChangesAsync();
            return invoicetotal;
        }

        public async Task<InvoiceTotal?> GetByIdAsync(int invoicetotalId)
        {
            return await _context
                .InvoiceTotals
                .Where(x => x.Id == invoicetotalId).FirstOrDefaultAsync();
        }

        public async Task<bool> InvoiceTotalExistsAsync(string invoicetotalCode)
        {
            return _context
                     .InvoiceTotals
                     .Any(c => c.Name == invoicetotalCode);
        }
    }
}
