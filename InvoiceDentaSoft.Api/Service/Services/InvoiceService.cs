using InvoiceDentaSoft.Api.Dto_s.Requests.Invoice;
using InvoiceDentaSoft.Api.Dto_s.Responses.Invoice;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using InvoiceDentaSoft.Api.Service.Repositories.Interfaces;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDentaSoft.Api.Service.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IVendorRepository _vendorRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository, IVendorRepository vendorRepository)
        {
            _invoiceRepository = invoiceRepository;
            _vendorRepository = vendorRepository;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _invoiceRepository.GetAllInvoicesAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _invoiceRepository.GetInvoiceByIdAsync(id);
        }

        public async Task<CreateInvoiceResponse> CreateInvoiceAsync(CreateInvoiceRequest request)
        {
            //check if invoice exists by InvoiceNumber
            if (await _invoiceRepository.InvoiceExistsAsync(request.InvoiceNumber))
            {
                throw new Exception("The invoice already exists  with such InvoiceNumber!");
            }

            var createdAt = DateTime.UtcNow;

            var contact = await GetVendor(request.ContactId);

            var invoice = new Invoice()
            {
                CompanyId = request.CompanyId,
                InvoiceNumber= request.InvoiceNumber,
                OrderNumber = request.OrderNumber,
                Status = request.Status,
                InvoicedAt = request.InvoicedAt,
                DueAt = request.DueAt,
                Amount = request.Amount,
                CurrencyCode = request.CurrencyCode,
                CurrencyRate = request.CurrencyRate,
                CategoryId = request.CategoryId,
                ContactId = request.ContactId,
                ContactName = contact.Name,
                ContactEmail = contact.Email,
                ContactTaxNumber = contact.TaxNumber,
                ContactPhone = contact.Phone,
                ContactAddress = contact.Address,
                Notes = request.Notes,
                Footer = request.Footer,
                ParentId = request.ParentId,
                CreatedAt = createdAt
            };


            var entity = await _invoiceRepository.CreateInvoiceAsync(invoice);

            return new CreateInvoiceResponse
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                InvoiceNumber = entity.InvoiceNumber,
                OrderNumber = entity.OrderNumber,
                Status = entity.Status,
                InvoicedAt = entity.InvoicedAt,
                DueAt = entity.DueAt,
                Amount = entity.Amount,
                CurrencyCode = entity.CurrencyCode,
                CurrencyRate = entity.CurrencyRate,
                CategoryId = entity.CategoryId,
                ContactId = entity.ContactId,
                ContactName = entity.ContactName,
                ContactEmail = entity.ContactEmail,
                ContactTaxNumber = entity.ContactTaxNumber,
                ContactPhone = entity.ContactPhone,
                ContactAddress = entity.ContactAddress,
                Notes = entity.Notes,
                Footer = entity.Footer,
                ParentId = entity.ParentId,
                CreatedAt = createdAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };
        }


        public async Task<UpdateInvoiceResponse> UpdateInvoiceAsync(UpdateInvoiceRequest? updateRequest)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(updateRequest.Id);
            if (invoice == null)
            {
                throw new Exception("There is no invoice with such Id!");
            }
            var updatedAt = DateTime.UtcNow;

            var contact = await GetVendor(updateRequest.ContactId);

            invoice.CompanyId = updateRequest.CompanyId;
            invoice.InvoiceNumber = updateRequest.InvoiceNumber;
            invoice.OrderNumber = updateRequest.OrderNumber;
            invoice.Status = updateRequest.Status;
            invoice.InvoicedAt = updatedAt;
            invoice.DueAt = updatedAt;
            invoice.Amount = updateRequest.Amount;
            invoice.CurrencyCode = updateRequest.CurrencyCode;
            invoice.CurrencyRate = updateRequest.CurrencyRate;
            invoice.CategoryId = updateRequest.CategoryId;
            invoice.ContactId = updateRequest.ContactId;
            invoice.ContactName = contact.Name;
            invoice.ContactEmail = contact.Email;
            invoice.ContactTaxNumber = contact.TaxNumber;
            invoice.ContactPhone = contact.Phone;
            invoice.ContactAddress = contact.Address;
            invoice.Notes = updateRequest.Notes;
            invoice.Footer = updateRequest.Footer;
            invoice.ParentId = updateRequest.ParentId;
            invoice.UpdatedAt = updatedAt;

            var entity = await _invoiceRepository.UpdateInvoiceAsync(invoice);

            var response = new UpdateInvoiceResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                InvoiceNumber = entity.InvoiceNumber,
                OrderNumber = entity.OrderNumber,
                Status = entity.Status,
                InvoicedAt = entity.InvoicedAt,
                DueAt = entity.DueAt,
                Amount = entity.Amount,
                CurrencyCode = entity.CurrencyCode,
                CurrencyRate = entity.CurrencyRate,
                CategoryId = entity.CategoryId,
                ContactId = entity.ContactId,
                ContactName = entity.ContactName,
                ContactEmail = entity.ContactEmail,
                ContactTaxNumber = entity.ContactTaxNumber,
                ContactPhone = entity.ContactPhone,
                ContactAddress = entity.ContactAddress,
                Notes = entity.Notes,
                Footer = entity.Footer,
                ParentId = entity.ParentId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };
            return response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task DeleteInvoiceAsync(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice == null)
            {
                throw new Exception("There is no invoice with such Id!");
            }

            var entity = await _invoiceRepository.DeleteAsync(invoice);
        }


        public async Task<bool> InvoiceExistsAsync(string invoiceName)
        {
            return await _invoiceRepository.InvoiceExistsAsync(invoiceName);
        }

        public async Task<Vendor> GetVendor(int? vendorId)
        {
            var entity = await _vendorRepository.GetByIdAsync((int)vendorId);

            if (entity == null)
            {
                throw new Exception("There is no invoice type with such Id!!");
            }
            return entity;
        }
    }
}




