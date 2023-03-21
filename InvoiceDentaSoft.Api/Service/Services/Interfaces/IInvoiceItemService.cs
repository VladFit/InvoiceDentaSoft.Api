using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceItem;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceItem;
using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Services.Interfaces
{
    public interface IInvoiceItemService
    {
        Task<IEnumerable<InvoiceItem>> GetAllInvoiceItems();
        Task<CreateInvoiceItemResponse> CreateInvoiceItemAsync(CreateInvoiceItemRequest request);
        Task<UpdateInvoiceItemResponse> UpdateInvoiceItemAsync(UpdateInvoiceItemRequest? updateRequest);
        Task DeleteInvoiceItemAsync(int invoicetemId);
        Task<bool> InvoiceItemExistsAsync(string name);
    }
}
