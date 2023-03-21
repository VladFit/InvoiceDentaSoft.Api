using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceTotal;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceTotal;
using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Services.Interfaces
{
    public interface IInvoiceTotalService
    {
        Task<IEnumerable<InvoiceTotal>> GetAllInvoiceTotals();
        Task<CreateInvoiceTotalResponse> CreateInvoiceTotalAsync(CreateInvoiceTotalRequest request);
        Task<UpdateInvoiceTotalResponse> UpdateInvoiceTotalAsync(UpdateInvoiceTotalRequest? updateRequest);
        Task DeleteInvoiceTotalAsync(int invoicetotalId);
        Task<bool> InvoiceTotalExistsAsync(string code);
    }
}
