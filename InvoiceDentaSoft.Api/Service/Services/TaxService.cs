using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.Taxes;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.Taxes;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDentaSoft.Api.Service.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _repository;

        public TaxService(ITaxRepository repository)
        {
            _repository = repository;
        }

        /// <summary>Get all taxes.</summary>
        /// <param name="getRequest">The get request.</param>
        /// <returns>return List of Taxes<br /></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Tax>> GetAllTaxes()
        {
            return await _repository.GetAllAsync();
        }

        /// <summary>Creates new tax.</summary>
        /// <param name="createRequest">The create request.</param>
        /// <returns>return CreateTaxResponse<br /></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CreateTaxResponse> CreateTaxAsync(CreateTaxRequest request)
        {
            //check if tax exists by Name
            if (await _repository.TaxExistsAsync(request.Name))
            {
                throw new Exception("The tax already exists with such Name");
            }

            var createdAt = DateTime.UtcNow;

            var tax = new Tax(
                request.CompanyId,
                request.Name,
                request.Rate,
                request.Type,
                request.Enabled,
                createdAt);

            var entity = await _repository.AddAsync(tax);

            var response = new CreateTaxResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Rate = entity.Rate,
                Type = entity.Type,
                Enabled = entity.Enabled,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        /// <summary>Updates the tax that exists asynchronous.</summary>
        /// <param name="updateRequest">The update request.</param>
        /// <param name="Id">The temporary tax identifier.</param>
        /// <returns>return UpdateTaxResponse</returns>
        public async Task<UpdateTaxResponse> UpdateTaxAsync(UpdateTaxRequest? updateRequest)
        {
            var tax = await _repository.GetByIdAsync(updateRequest.Id);
            if (tax == null)
            {
                throw new Exception("There is no category with such Id!");
            }

            var updatedAt = DateTime.UtcNow;

            tax.CompanyId = updateRequest.CompanyId;
            tax.Name = updateRequest.Name;
            tax.Rate = updateRequest.Rate;
            tax.Type = updateRequest.Type;
            tax.Enabled = updateRequest.Enabled;
            tax.UpdatedAt = updatedAt;

            var entity = await _repository.UpdateAsync(tax);

            var response = new UpdateTaxResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Rate = entity.Rate,
                Type = entity.Type,
                Enabled = entity.Enabled,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        /// <summary>Deletes the tax info and fully removed it asynchronous.</summary>
        /// <param name="taxId">The tax identifier.</param>
        /// <returns>return DeleteTaxResponse</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task DeleteTaxAsync(int taxId)
        {
            var tax = await _repository.GetByIdAsync(taxId);
            if (tax == null)
            {
                throw new Exception("There is no tax with such Id!");
            }

            var entity = await _repository.DeleteAsync(tax);

        }
    }
}
