using InvoiceDentaSoft.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDentaSoft.Api.Service.Repositories.Intefaces
{
    public interface IInvoiceHistoryRepository
    {
        Task<IEnumerable<InvoiceHistory>> GetAllAsync();
        Task<InvoiceHistory> AddAsync(InvoiceHistory category);
        Task<InvoiceHistory> UpdateInvoiceHistoryAsync(InvoiceHistory invoiceHistory);
        Task<InvoiceHistory> DeleteAsync(InvoiceHistory invoiceHistory);
        Task<InvoiceHistory?> GetByIdAsync(int categoryId);
        Task<bool> InvoiceHistoryExistsAsync(string description);
    }
}
