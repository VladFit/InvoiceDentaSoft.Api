using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceHistory;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceHistory;
using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Services.Interfaces
{
    public interface IInvoiceHistoryService
    {
        Task<IEnumerable<InvoiceHistory>> GetAllInvoiceHistories();
        Task<CreateInvoiceHistoryResponse> CreateCreateInvoiceHistoryAsync(CreateInvoiceHistoryRequest request);
        Task<UpdateInvoiceHistoryResponse> UpdateInvoiceHistoryAsync(UpdateInvoiceHistoryRequest? updateRequest);
        Task DeleteInvoiceHistoryAsync(int invoiceHistoryId);
        Task<bool> InvoiceHistoryExistsAsync(string description);
    }
}
