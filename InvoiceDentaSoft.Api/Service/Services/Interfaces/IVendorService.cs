using InvoiceDentaSoft.Api.Dto_s.Requests.Vendors;
using InvoiceDentaSoft.Api.Dto_s.Responses.Vendors;
using InvoiceDentaSoft.Api.Entities;

namespace InvoiceDentaSoft.Api.Service.Services.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<Vendor>> GetAllVendors();
        Task<CreateVendorResponse> CreateVendorAsync(CreateVendorRequest request);
        Task<UpdateVendorResponse> UpdateVendorAsync(UpdateVendorRequest? updateRequest);
        Task DeleteVendorAsync(int vendorId);
    }
}
