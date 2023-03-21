using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceTotal;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceTotal;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;

namespace InvoiceDentaSoft.Api.Service.Services
{
    public class InvoiceTotalService : IInvoiceTotalService
    {
        private readonly IInvoiceTotalRepository _invoiceTotalRepository;

        public InvoiceTotalService(IInvoiceTotalRepository invoiceTotalRepository)
        {
            _invoiceTotalRepository = invoiceTotalRepository;
        }

        public async Task<IEnumerable<InvoiceTotal>> GetAllInvoiceTotals()
        {
            return await _invoiceTotalRepository.GetAllInvoiceTotalsAsync();
        }

        public async Task<CreateInvoiceTotalResponse> CreateInvoiceTotalAsync(CreateInvoiceTotalRequest request)
        {
            //check if InvoiceTotal exists by Name
            if (await _invoiceTotalRepository.InvoiceTotalExistsAsync(request.Code))
            {
                throw new Exception("The InvoiceTotal already exists  with such Code!");
            }

            var createdAt = DateTime.UtcNow;

            var invoicetotal = new InvoiceTotal(
                request.CompanyId,
                request.InvoiceId,
                request.Code,
                request.Name,
                request.Amount,
                request.SortOrder,
                createdAt);

            var entity = await _invoiceTotalRepository.AddInvoiceTotalAsync(invoicetotal);

            var response = new CreateInvoiceTotalResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                InvoiceId = entity.InvoiceId,
                Code = entity.Code,
                Name = entity.Name,
                Amount = entity.Amount,
                SortOrder = entity.SortOrder,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        public async Task<UpdateInvoiceTotalResponse> UpdateInvoiceTotalAsync(UpdateInvoiceTotalRequest? updateRequest)
        {
            var invoicetotal = await _invoiceTotalRepository.GetByIdAsync(updateRequest.Id);
            if (invoicetotal == null)
            {
                throw new Exception("There is no InvoiceTotal with such Id!");
            }

            var updatedAt = DateTime.UtcNow;

            invoicetotal.CompanyId = updateRequest.CompanyId;
            invoicetotal.InvoiceId = updateRequest.InvoiceId;
            invoicetotal.Code = updateRequest.Code;
            invoicetotal.Name = updateRequest.Name;
            invoicetotal.Amount = updateRequest.Amount;
            invoicetotal.SortOrder = updateRequest.SortOrder;
            invoicetotal.UpdatedAt = updatedAt;

            var entity = await _invoiceTotalRepository.UpdateInvoiceTotalAsync(invoicetotal);

            var response = new UpdateInvoiceTotalResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                InvoiceId = entity.InvoiceId,
                Code = entity.Code,
                Name = entity.Name,
                Amount = entity.Amount,
                SortOrder = entity.SortOrder,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        public async Task DeleteInvoiceTotalAsync(int invoicetotalId)
        {
            var invoicetotal = await _invoiceTotalRepository.GetByIdAsync(invoicetotalId);
            if (invoicetotal == null)
            {
                throw new Exception("There is no invoiceTotal with such Id!");
            }

            var entity = await _invoiceTotalRepository.DeleteAsync(invoicetotal);

        }

        public async Task<bool> InvoiceTotalExistsAsync(string code)
        {
            return await _invoiceTotalRepository.InvoiceTotalExistsAsync(code);
        }
    }
}
