using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceHistory;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceHistory;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InvoiceDentaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceHistoriesController : ControllerBase
    {
        private readonly IInvoiceHistoryService _invoiceHistoryService;

        public InvoiceHistoriesController(IInvoiceHistoryService invoiceHistoryService)
        {
            _invoiceHistoryService = invoiceHistoryService;
        }

        /// <summary>Get all InvoiceHistories.</summary>
        /// <param name="request">The request.</param>
        /// <returns>return OkResponse</returns>
        [HttpGet("allinvoicehistories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Give a list of all InvoiceHistories",
            Description = "Returns the List of InvoiceHistories",
            OperationId = "InvoiceHistoriesController.GetAllInvoiceHistories")
        ]
        public async Task<ActionResult<IEnumerable<InvoiceHistory>>> GetAllCategories()
        {
            var response = await _invoiceHistoryService.GetAllInvoiceHistories();
            return Ok(response);
        }

        /// <summary>Creates the InvoiceHistory.</summary>
        /// <param name="request">The request.</param>
        /// <returns>return CreateInvoiceHistoryResponse</returns>
        [HttpPost("createinvoicehistory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(
            Summary = "Creates new invoice history.",
            Description = "Creates new InvoiceHistory.",
            OperationId = "InvoiceHistoriesController.CreateInvoiceHistory")]
        public async Task<ActionResult<CreateInvoiceHistoryResponse>> CreateInvoiceHistory(CreateInvoiceHistoryRequest request)
        {
            var response = await _invoiceHistoryService.CreateCreateInvoiceHistoryAsync(request);
            return Created($"/{response.Id}", response);
        }

        /// <summary>Updates the specified request.</summary>
        /// <param name="request">The request.</param>
        /// <param name="Id">The invoiceHistory identifier.</param>
        /// <returns>return UpdateInvoiceHistoryResponse</returns>
        [HttpPut("updateinvoicehistory")]
        [SwaggerOperation(
            Summary = "Updates invoiceHistory info.",
            Description = "Updates info in invoiceHistory that already exists.",
            OperationId = "InvoiceHistoriesController.UpdateInvoiceHistory")]
        public async Task<ActionResult<UpdateInvoiceHistoryResponse>> UpdateInvoiceHistory(UpdateInvoiceHistoryRequest? request)
        {
            var response = await _invoiceHistoryService.UpdateInvoiceHistoryAsync(request);
            return Ok(response);
        }

        /// <summary>Deletes the invoiceHistory identifier.</summary>
        /// <param name="invoiceHistoryId">The invoiceHistory identifier.</param>
        /// <returns>return NoContent</returns>
        [HttpDelete("deleteinvoicehistory{invoiceHistoryId}")]
        [SwaggerOperation(
            Summary = "Deletes invoiceHistory.",
            Description = "Deletes all info about invoiceHistory and remove it.",
            OperationId = "InvoiceHistoriesController.DeleteInvoiceHistory")]
        public async Task<ActionResult> DeleteInvoiceHistory(int invoiceHistoryId)
        {
            await _invoiceHistoryService.DeleteInvoiceHistoryAsync(invoiceHistoryId);
            return NoContent();
        }
    }
}
