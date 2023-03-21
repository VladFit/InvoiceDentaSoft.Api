using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Repositories.Intefaces
{
    public interface IInvoiceItemTaxRepository
    {
        Task<IEnumerable<InvoiceItemTax>> GetAllInvoiceItemTaxesAsync();
        Task<InvoiceItemTax> AddInvoiceItemTaxAsync(InvoiceItemTax invoiceitemtax);
        Task<InvoiceItemTax> UpdateInvoiceItemTaxAsync(InvoiceItemTax invoiceitemtax);
        Task<InvoiceItemTax> DeleteAsync(InvoiceItemTax invoiceitemtax);
        Task<InvoiceItemTax?> GetByIdAsync(int invoiceitemtaxId);
        Task<bool> InvoiceItemTaxExistsAsync(string invoiceitemtaxName);
    }
}
