using InvoiceDentaSoft.Api.Context;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDentaSoft.Api.Service.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        private readonly ApplicationDbContext _context;

        public TaxRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tax>> GetAllAsync()
        {
            return await _context.Taxes.ToListAsync();
        }
        public async Task<Tax> AddAsync(Tax tax)
        {
            _context.Taxes.Add(tax);
            await _context.SaveChangesAsync();
            return tax;
        }

        public async Task<Tax> UpdateAsync(Tax tax)
        {
            _context.Taxes.Update(tax);
            await _context.SaveChangesAsync();
            return tax;
        }

        public async Task<Tax> DeleteAsync(Tax tax)
        {
            _context.Taxes.Remove(tax);
            //category.Enabled = false;
            await _context.SaveChangesAsync();
            return tax;
        }

        

        public async Task<Tax?> GetByIdAsync(int taxId)
        {
            return await _context.Taxes.Where(c => c.Id == taxId).FirstOrDefaultAsync();
        }

        public async Task<bool> TaxExistsAsync(string name)
        {
            return _context
                     .Taxes
                     .Any(c => c.Name == name);
        }

        
    }
}
