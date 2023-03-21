using InvoiceDentaSoft.Api.Dto_s.Models.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceHistory;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceHistory;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Repositories;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDentaSoft.Api.Service.Services
{
    public class InvoiceHistoryService : IInvoiceHistoryService
    {
        private readonly IInvoiceHistoryRepository _invoiceHistoryRepository;

        public InvoiceHistoryService(IInvoiceHistoryRepository invoiceHistoryRepository)
        {
            _invoiceHistoryRepository = invoiceHistoryRepository;
        }

        /// <summary>Get all invoice history.</summary>
        /// <param name="getRequest">The get request.</param>
        /// <returns>return List of InvoiceHistory<br /></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<InvoiceHistory>> GetAllInvoiceHistories()
        {
            return await _invoiceHistoryRepository.GetAllAsync();
        }

        /// <summary>Creates new invoice history.</summary>
        /// <param name="createRequest">The create request.</param>
        /// <returns>return CreateInvoiceHistoryResponse<br /></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CreateInvoiceHistoryResponse> CreateCreateInvoiceHistoryAsync(CreateInvoiceHistoryRequest request)
        {
            //check if category exists by Name
            if (await _invoiceHistoryRepository.InvoiceHistoryExistsAsync(request.Description))
            {
                throw new Exception("The InvoiceHistory already exists with such Description");
            }

            var createdAt = DateTime.UtcNow;

            var invoiceHistory = new InvoiceHistory(
                request.CompanyId,
                request.InvoiceId,
                request.Status,
                request.Notify,
                request.Description,
                createdAt);

            var entity = await _invoiceHistoryRepository.AddAsync(invoiceHistory);

            var response = new CreateInvoiceHistoryResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                InvoiceId = entity.InvoiceId,
                Status = entity.Status,
                Notify = entity.Notify, 
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        /// <summary>Updates the invoiceHistory that exists asynchronous.</summary>
        /// <param name="updateRequest">The update request.</param>
        /// <param name="Id">The invoiceHistory identifier.</param>
        /// <returns>return UpdateInvoiceHistoryResponse</returns>
        public async Task<UpdateInvoiceHistoryResponse> UpdateInvoiceHistoryAsync(UpdateInvoiceHistoryRequest? updateRequest)
        {
            var invoiceHistory = await _invoiceHistoryRepository.GetByIdAsync(updateRequest.Id);
            if (invoiceHistory == null)
            {
                throw new Exception("There is no category with such Id!");
            }

            var updatedAt = DateTime.UtcNow;

            invoiceHistory.CompanyId = updateRequest.CompanyId;
            invoiceHistory.InvoiceId = updateRequest.InvoiceId;
            invoiceHistory.Status = updateRequest.Status;
            invoiceHistory.Notify = updateRequest.Notify;
            invoiceHistory.Description = updateRequest.Description;
            invoiceHistory.UpdatedAt = updatedAt;
            

            var entity = await _invoiceHistoryRepository.UpdateInvoiceHistoryAsync(invoiceHistory);

            var response = new UpdateInvoiceHistoryResponse()
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                InvoiceId = entity.InvoiceId,
                Status = updateRequest.Status,
                Notify = updateRequest.Notify, 
                Description = updateRequest.Description,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                DeletedAt = entity.DeletedAt
            };

            return response;
        }

        /// <summary>Deletes the invoiceHistory info and fully removed it asynchronous.</summary>
        /// <param name="invoiceHistoryId">The invoiceHistory identifier.</param>
        /// <returns>return DeleteInvoiceHistoryResponse</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task DeleteInvoiceHistoryAsync(int invoiceHistoryId)
        {
            var invoiceHistory = await _invoiceHistoryRepository.GetByIdAsync(invoiceHistoryId);
            if (invoiceHistory == null)
            {
                throw new Exception("There is no invoiceHistoryId with such Id!");
            }

            var entity = await _invoiceHistoryRepository.DeleteAsync(invoiceHistory);

        }

        /// <summary>Check if invoiceHistory exists by description.</summary>
        /// <param name="description">The description.</param>
        /// <returns>return bool</returns>`1
        public async Task<bool> InvoiceHistoryExistsAsync(string description)
        {
            return await _invoiceHistoryRepository.InvoiceHistoryExistsAsync(description);
        }
    }
}
