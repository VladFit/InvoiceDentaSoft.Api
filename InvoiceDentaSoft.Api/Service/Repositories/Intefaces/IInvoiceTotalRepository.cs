using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Repositories.Intefaces
{
    public interface IInvoiceTotalRepository
    {
        Task<IEnumerable<InvoiceTotal>> GetAllInvoiceTotalsAsync();
        Task<InvoiceTotal> AddInvoiceTotalAsync(InvoiceTotal invoicetotal);
        Task<InvoiceTotal> UpdateInvoiceTotalAsync(InvoiceTotal invoicetotal);
        Task<InvoiceTotal> DeleteAsync(InvoiceTotal invoicetotal);
        Task<InvoiceTotal?> GetByIdAsync(int invoicetotalId);
        Task<bool> InvoiceTotalExistsAsync(string invoicetotalCode);
    }
}
