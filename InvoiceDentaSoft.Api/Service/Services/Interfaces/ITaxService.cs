using InvoiceDentaSoft.Api.Dto_s.Requests.Taxes;
using InvoiceDentaSoft.Api.Dto_s.Responses.Taxes;
using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Services.Interfaces
{
    public interface ITaxService
    {
        Task<IEnumerable<Tax>> GetAllTaxes();
        Task<CreateTaxResponse> CreateTaxAsync(CreateTaxRequest request);
        Task<UpdateTaxResponse> UpdateTaxAsync(UpdateTaxRequest? updateRequest);
        Task DeleteTaxAsync(int taxId);
    }
}
