using InvoiceDentaSoft.Api.Context;
using InvoiceDentaSoft.Api.Dto_s.Requests.Invoice;
using InvoiceDentaSoft.Api.Dto_s.Responses.Invoice;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace InvoiceDentaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }


        [HttpGet("allinvoices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Give a list of all Invoices",
            Description = "Returns the List of Invoices",
            OperationId = "InvoiceController.GetAllInvoices")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAllInvoices()
        {
            var response = await _invoiceService.GetAllInvoicesAsync();
            return Ok();
        }

        [HttpPost("createinvoice")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(
            Summary = "Creates new invoice.",
            Description = "Creates new invoice.",
            OperationId = "InvoiceController.CreateInvoice")]
        public async Task<ActionResult<CreateInvoiceResponse>> CreateInvoice(CreateInvoiceRequest request)
        {
            var response = await _invoiceService.CreateInvoiceAsync(request);
            return Created($"/{response.Id}", response);
        }

        [HttpPut("updateinvoice")]
        [SwaggerOperation(
            Summary = "Updates invoice info.",
            Description = "Updates info in invoice that already exists.",
            OperationId = "InvoicesController.UpdateInvoice")]
        public async Task<UpdateInvoiceResponse> UpdateInvoice(UpdateInvoiceRequest? request)
        {
            var response = await _invoiceService.UpdateInvoiceAsync(request);
            return response;
        }

        [HttpDelete("deleteinvoice{invoiceId}")]
        [SwaggerOperation(
            Summary = "Deletes invoice.",
            Description = "Deletes all info about invoice and remove it.",
            OperationId = "InvoiceController.DeleteCategory")]
        public async Task<ActionResult> DeleteInvoice(int invoiceId)
        {
            await _invoiceService.DeleteInvoiceAsync(invoiceId);
            return NoContent();
        }
    }
}
