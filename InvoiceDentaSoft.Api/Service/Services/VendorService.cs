using InvoiceDentaSoft.Api.Dto_s.Requests.Taxes;
using InvoiceDentaSoft.Api.Dto_s.Requests.Vendors;
using InvoiceDentaSoft.Api.Dto_s.Responses.Taxes;
using InvoiceDentaSoft.Api.Dto_s.Responses.Vendors;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Entities.LoockUps;
using InvoiceDentaSoft.Api.Service.Repositories.Generic;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDentaSoft.Api.Service.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _repository;
        private readonly IGenericRepository<VendorType> _vendorTypeRepository;

        public VendorService(IVendorRepository repository, IGenericRepository<VendorType> vendorTypeRepository)
        {
            _repository = repository;
            _vendorTypeRepository = vendorTypeRepository;
        }

        /// <summary>Get all vendors.</summary>
        /// <param name="getRequest">The get request.</param>
        /// <returns>return List of Vendors<br /></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Vendor>> GetAllVendors()
        {
            return await _repository.GetAllAsync();
        }

        /// <summary>Creates new vendor.</summary>
        /// <param name="createRequest">The create request.</param>
        /// <returns>return CreateVendorResponse<br /></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CreateVendorResponse> CreateVendorAsync(CreateVendorRequest request)
        {
            //check if tax exists by Name
            if (await _repository.VendorExistsAsync(request.Email))
            {
                throw new Exception("The Vendor already exists with such Email");
            }

            var createdAt = DateTime.UtcNow;
            var vendorType = await GetVendorType(request.Type);

            var vendor = new Vendor(
                request.CompanyId,
                vendorType.Name,
                request.Name,
                request.Email,
                request.UserId,
                request.TaxNumber,
                request.Phone,
                request.Address,
                request.Website,
                request.CurrencyCode,
                request.Enabled,
                request.Reference,
                request.ClinicId,
                createdAt);

            var entity = await _repository.AddAsync(vendor);

            var response = new CreateVendorResponse
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Type = entity.Type,
                Name = entity.Name,
                Email = entity.Email,
                UserId = entity.UserId,
                TaxNumber = entity.TaxNumber,
                Phone = entity.Phone,
                Address = entity.Address,
                Website = entity.Website,
                CurrencyCode = entity.CurrencyCode,
                Enabled = entity.Enabled,
                Reference = entity.Reference,
                ClinicId = entity.ClinicId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        /// <summary>Updates the vendor that exists asynchronous.</summary>
        /// <param name="updateRequest">The update request.</param>
        /// <param name="Id">The temporary vendor identifier.</param>
        /// <returns>return UpdateVendorResponse</returns>
        public async Task<UpdateVendorResponse> UpdateVendorAsync(UpdateVendorRequest? updateRequest)
        {
            var vendor = await _repository.GetByIdAsync(updateRequest.Id);
            if (vendor == null)
            {
                throw new Exception("There is no category with such Id!");
            }

            var updatedAt = DateTime.UtcNow;
            var vendorType = await GetVendorType(updateRequest.Type);

            vendor.CompanyId = updateRequest.CompanyId;
            vendor.Type = vendorType.Name;
            vendor.Name = updateRequest.Name;
            vendor.Email = updateRequest.Email;
            vendor.UserId = updateRequest.UserId;
            vendor.TaxNumber = updateRequest.TaxNumber;
            vendor.Phone = updateRequest.Phone;
            vendor.Address = updateRequest.Address;
            vendor.Website = updateRequest.Website;
            vendor.CurrencyCode = updateRequest.CurrencyCode;
            vendor.Enabled = updateRequest.Enabled;
            vendor.Reference = updateRequest.Reference;
            vendor.ClinicId = updateRequest.ClinicId;
            vendor.UpdatedAt = updatedAt;

            var entity = await _repository.UpdateAsync(vendor);

            var response = new UpdateVendorResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Type = entity.Type,
                Name = entity.Name,
                Email = entity.Email,
                UserId = entity.UserId,
                TaxNumber = entity.TaxNumber,
                Phone = entity.Phone,
                Address = entity.Address,
                Website = entity.Website,
                CurrencyCode = entity.CurrencyCode,
                Enabled = entity.Enabled,
                Reference = entity.Reference,
                ClinicId = entity.ClinicId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        /// <summary>Deletes the vendor info and fully removed it asynchronous.</summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>return DeleteVendorResponse</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task DeleteVendorAsync(int vendorId)
        {
            var vendor = await _repository.GetByIdAsync(vendorId);
            if (vendor == null)
            {
                throw new Exception("There is no tax with such Id!");
            }

            var entity = await _repository.DeleteAsync(vendor);

        }

        public async Task<VendorType> GetVendorType(int? vendortypeId)
        {
            var entity = await _vendorTypeRepository.GetByIdAsync(vendortypeId);

            //check if VendorType exists by Name
            if (entity == null)
            {
                throw new Exception("There is no vendor type with such Id!!");
            }
            return entity;
        }
    }
}
