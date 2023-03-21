using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceItemTax;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceItemTax;
using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Services.Interfaces
{
    public interface IInvoiceItemTaxService
    {
        Task<IEnumerable<InvoiceItemTax>> GetAllInvoiceItemTaxes();
        Task<CreateInvoiceItemTaxResponse> CreateInvoiceItemTaxAsync(CreateInvoiceItemTaxRequest request);
        Task<UpdateInvoiceItemTaxResponse> UpdateInvoiceItemTaxAsync(UpdateInvoiceItemTaxRequest? updateRequest);
        Task DeleteInvoiceItemTaxAsync(int invoiceitemtaxId);
        Task<bool> InvoiceItemTaxExistsAsync(string name);
    }
}
