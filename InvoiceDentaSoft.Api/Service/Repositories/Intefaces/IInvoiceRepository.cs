using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(int id);
        Task<Invoice> CreateInvoiceAsync(Invoice invoice);
        Task<Invoice> UpdateInvoiceAsync(Invoice invoice);
        Task<Invoice> DeleteAsync(Invoice invoice);
        Task<Invoice?> GetByIdAsync(int invoiceId);
        Task<bool> InvoiceExistsAsync(string name);
    }
}