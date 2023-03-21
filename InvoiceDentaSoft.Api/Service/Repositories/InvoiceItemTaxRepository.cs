using InvoiceDentaSoft.Api.Context;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDentaSoft.Api.Service.Repositories
{
    public class InvoiceItemTaxRepository : IInvoiceItemTaxRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceItemTaxRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceItemTax>> GetAllInvoiceItemTaxesAsync()
        {

            return await _context.InvoiceItemTaxes.ToListAsync();
        }

        public async Task<InvoiceItemTax> AddInvoiceItemTaxAsync(InvoiceItemTax invoiceitemtax)
        {
            _context.InvoiceItemTaxes.Add(invoiceitemtax);
            await _context.SaveChangesAsync();
            return invoiceitemtax;
        }

        public async Task<InvoiceItemTax> UpdateInvoiceItemTaxAsync(InvoiceItemTax invoiceitemtax)
        {
            _context.InvoiceItemTaxes.Update(invoiceitemtax);
            await _context.SaveChangesAsync();
            return invoiceitemtax;
        }

        public async Task<InvoiceItemTax> DeleteAsync(InvoiceItemTax invoiceitemtax)
        {
            _context.InvoiceItemTaxes.Remove(invoiceitemtax);
            await _context.SaveChangesAsync();
            return invoiceitemtax;
        }

        public async Task<InvoiceItemTax?> GetByIdAsync(int invoiceitemtaxId)
        {
            return await _context
                .InvoiceItemTaxes
                .Where(x => x.Id == invoiceitemtaxId).FirstOrDefaultAsync();
        }

        public async Task<bool> InvoiceItemTaxExistsAsync(string invoiceitemtaxName)
        {
            return _context
                     .InvoiceItemTaxes
                     .Any(c => c.Name == invoiceitemtaxName);
        }
    }
}
