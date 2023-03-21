using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceItem;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceItem;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Services;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InvoiceDentaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IInvoiceItemService _invoiceItemService;

        public InvoiceItemController(IInvoiceItemService invoiceItemService)
        {
            _invoiceItemService = invoiceItemService;
        }

        [HttpGet("allinvoiceitems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Give a list of all InvoiceItems",
            Description = "Returns the List of InvoiceItems",
            OperationId = "InvoiceItemsController.GetAllInvoiceItems")
        ]
        public async Task<ActionResult<IEnumerable<InvoiceItem>>> GetAllInvoiceItems()
        {
            var response = await _invoiceItemService.GetAllInvoiceItems();
            return Ok(response);
        }

        [HttpPost("createinvoiceitem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(
            Summary = "Creates new invoiceitem.",
            Description = "Creates new invoiceitem.",
            OperationId = "InvoiceItemController.CreateInvoiceItem")]
        public async Task<ActionResult<CreateInvoiceItemResponse>> CreateInvoiceItem(CreateInvoiceItemRequest request)
        {
            var response = await _invoiceItemService.CreateInvoiceItemAsync(request);
            return Created($"/{response.Id}", response);
        }

        [HttpPut("updateinvoiceitem")]
        [SwaggerOperation(
            Summary = "Updates invoice item info.",
            Description = "Updates info in invoice item that already exists.",
            OperationId = "InvoiceItemController.UpdateInvoiceItem")]
        public async Task<UpdateInvoiceItemResponse> UpdateInvoiceItem(UpdateInvoiceItemRequest? request)
        {
            var response = await _invoiceItemService.UpdateInvoiceItemAsync(request);
            return response;
        }

        [HttpDelete("deleteinvoiceitem{invoiceItemId}")]
        [SwaggerOperation(
            Summary = "Deletes invoice item.",
            Description = "Deletes all info about invoice item and remove it.",
            OperationId = "InvoiceItemController.DeleteInvoiceItem")]
        public async Task<ActionResult> DeleteInvoiceItem(int invoiceitemId)
        {
            await _invoiceItemService.DeleteInvoiceItemAsync(invoiceitemId);
            return NoContent();
        }
    }
}
