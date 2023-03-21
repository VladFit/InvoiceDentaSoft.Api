using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Repositories.Intefaces
{
    public interface IInvoiceItemRepository
    {
        Task<IEnumerable<InvoiceItem>> GetAllInvoiceItemsAsync();
        Task<InvoiceItem> AddInvoiceItemAsync(InvoiceItem invoiceitem);
        Task<InvoiceItem> UpdateInvoiceItemAsync(InvoiceItem invoiceitem);
        Task<InvoiceItem> DeleteAsync(InvoiceItem invoiceitem);
        Task<InvoiceItem?> GetByIdAsync(int invoiceitemId);
        Task<bool> InvoiceItemExistsAsync(string sku);
    }
}
