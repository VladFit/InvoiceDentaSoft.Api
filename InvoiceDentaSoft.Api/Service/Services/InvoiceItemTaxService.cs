using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceItemTax;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceItemTax;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDentaSoft.Api.Service.Services
{
    public class InvoiceItemTaxService : IInvoiceItemTaxService
    {
        private readonly IInvoiceItemTaxRepository _invoiceItemTaxRepository;

        public InvoiceItemTaxService(IInvoiceItemTaxRepository invoiceItemTaxRepository)
        {
            _invoiceItemTaxRepository = invoiceItemTaxRepository;
        }

        public async Task<IEnumerable<InvoiceItemTax>> GetAllInvoiceItemTaxes()
        {
            return await _invoiceItemTaxRepository.GetAllInvoiceItemTaxesAsync();
        }

        public async Task<CreateInvoiceItemTaxResponse> CreateInvoiceItemTaxAsync(CreateInvoiceItemTaxRequest request)
        {
            //check if invoiceItemTax exists by Name
            if (await _invoiceItemTaxRepository.InvoiceItemTaxExistsAsync(request.Name))
            {
                throw new Exception("The invoiceItemTax already exists with such Name!");
            }

            var createdAt = DateTime.UtcNow;

            var invoiceitemtax = new InvoiceItemTax(
                request.CompanyId,
                request.InvoiceId,
                request.InvoiceItemId,
                request.TaxId,
                request.Name,
                request.Amount,
                createdAt);

            var entity = await _invoiceItemTaxRepository.AddInvoiceItemTaxAsync(invoiceitemtax);

            var response = new CreateInvoiceItemTaxResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                InvoiceId = entity.InvoiceId,
                InvoiceItemId = entity.InvoiceItemId,
                TaxId = entity.TaxId,
                Name = entity.Name,
                Amount = entity.Amount,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };
            return response;
        }

        public async Task<UpdateInvoiceItemTaxResponse> UpdateInvoiceItemTaxAsync(UpdateInvoiceItemTaxRequest? updateRequest)
        {
            var invoiceitemtax = await _invoiceItemTaxRepository.GetByIdAsync(updateRequest.Id);
            if (invoiceitemtax == null)
            {
                throw new Exception("There is no invoiceItemTax with such Id!");
            }

            var updatedAt = DateTime.UtcNow;

            invoiceitemtax.CompanyId = updateRequest.CompanyId;
            invoiceitemtax.InvoiceId = updateRequest.InvoiceId;
            invoiceitemtax.InvoiceItemId = updateRequest.InvoiceItemId;
            invoiceitemtax.TaxId = updateRequest.TaxId;
            invoiceitemtax.Name = updateRequest.Name;
            invoiceitemtax.Amount = updateRequest.Amount;
            invoiceitemtax.UpdatedAt = updatedAt;

            var entity = await _invoiceItemTaxRepository.UpdateInvoiceItemTaxAsync(invoiceitemtax);

            var response = new UpdateInvoiceItemTaxResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                InvoiceId = entity.InvoiceId,
                InvoiceItemId = entity.InvoiceItemId,
                TaxId = entity.TaxId,
                Name = entity.Name,
                Amount = entity.Amount,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = updatedAt,
                DeletedAt = entity.DeletedAt
            };
            return response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task DeleteInvoiceItemTaxAsync(int invoiceitemtaxId)
        {
            var invoiceitemtax = await _invoiceItemTaxRepository.GetByIdAsync(invoiceitemtaxId);
            if (invoiceitemtax == null)
            {
                throw new Exception("There is no invoiceItemTax with such Id!");
            }

            var entity = await _invoiceItemTaxRepository.DeleteAsync(invoiceitemtax);

        }

        public async Task<bool> InvoiceItemTaxExistsAsync(string name)
        {
            return await _invoiceItemTaxRepository.InvoiceItemTaxExistsAsync(name);
        }

    }
}
