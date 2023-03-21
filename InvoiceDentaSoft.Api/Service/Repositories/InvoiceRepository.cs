using InvoiceDentaSoft.Api.Context;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDentaSoft.Api.Service.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> UpdateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> DeleteAsync(Invoice invoice)
        {
            //var clinic = await GetByIdAsync(tempClinicId);

            //if (clinic is null)
            //{
            //    throw new Exception(DentaSoftApiDisplayMessages.ClinicNotFound);
            //}

            _context.Invoices.Remove(invoice);
            //invoice.Enabled = false;
            await _context.SaveChangesAsync();
            return invoice;

        }

        public async Task<Invoice?> GetByIdAsync(int invoiceId)
        {
            return await _context
                .Invoices
                .Where(x => x.Id == invoiceId).FirstOrDefaultAsync();
        }

        public async Task<bool> InvoiceExistsAsync(string invoiceNumber)
        {
            return await _context.Invoices.AnyAsync(i => i.InvoiceNumber == invoiceNumber);
        }
    }
}


