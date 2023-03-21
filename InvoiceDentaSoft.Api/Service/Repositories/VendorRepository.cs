using InvoiceDentaSoft.Api.Context;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDentaSoft.Api.Service.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ApplicationDbContext _context;

        public VendorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Vendor>> GetAllAsync()
        {
            return await _context.Vendors.ToListAsync();
        }
        public async Task<Vendor> AddAsync(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();
            return vendor;
        }

        public async Task<Vendor> UpdateAsync(Vendor vendor)
        {
            _context.Vendors.Update(vendor);
            await _context.SaveChangesAsync();
            return vendor;
        }

        public async Task<Vendor> DeleteAsync(Vendor vendor)
        {
            _context.Vendors.Remove(vendor);
            //category.Enabled = false;
            await _context.SaveChangesAsync();
            return vendor;
        }



        public async Task<Vendor?> GetByIdAsync(int taxId)
        {
            return await _context.Vendors.Where(c => c.Id == taxId).FirstOrDefaultAsync();
        }

        public async Task<bool> VendorExistsAsync(string email)
        {
            return _context
                     .Vendors
                     .Any(c => c.Email == email);
        }
    }
}
