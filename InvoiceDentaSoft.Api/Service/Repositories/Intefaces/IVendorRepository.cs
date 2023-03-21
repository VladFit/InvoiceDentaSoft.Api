using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Repositories.Intefaces
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetAllAsync();
        Task<Vendor> AddAsync(Vendor vendor);
        Task<Vendor> UpdateAsync(Vendor vendor);
        Task<Vendor> DeleteAsync(Vendor vendor);
        Task<Vendor?> GetByIdAsync(int taxId);
        Task<bool> VendorExistsAsync(string email);
    }
}
