using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Repositories.Intefaces
{
    public interface ITaxRepository
    {
        Task<IEnumerable<Tax>> GetAllAsync();
        Task<Tax> AddAsync(Tax tax);
        Task<Tax> UpdateAsync(Tax tax);
        Task<Tax> DeleteAsync(Tax tax);
        Task<Tax?> GetByIdAsync(int taxId);
        Task<bool> TaxExistsAsync(string name);
    }
}
