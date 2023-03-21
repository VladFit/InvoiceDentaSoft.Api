using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.Invoice;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.Invoice;
using InvoiceDentaSoft.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceDentaSoft.Api.Service.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(int id);
        Task<CreateInvoiceResponse> CreateInvoiceAsync(CreateInvoiceRequest request);
        Task<UpdateInvoiceResponse> UpdateInvoiceAsync(UpdateInvoiceRequest? updateRequest);
        Task DeleteInvoiceAsync(int invoiceId);
        Task<bool> InvoiceExistsAsync(string invoiceNumber);
    }
}


