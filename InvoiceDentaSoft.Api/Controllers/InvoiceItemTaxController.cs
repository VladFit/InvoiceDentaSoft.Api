using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceItemTax;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceItemTax;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Services;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InvoiceDentaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemTaxController : ControllerBase
    {
        private readonly IInvoiceItemTaxService _invoiceItemTaxService;
        public InvoiceItemTaxController(IInvoiceItemTaxService invoiceItemTaxService)
        {
            _invoiceItemTaxService = invoiceItemTaxService;
        }


        [HttpGet("allinvoiceitemtaxes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Give a list of all InvoiceItemTaxes",
            Description = "Returns the List of InvoiceItemTaxes",
            OperationId = "InvoiceItemTaxesController.GetAllInvoiceItemTaxes")
        ]
        public async Task<ActionResult<IEnumerable<InvoiceItemTax>>> GetAllInvoiceItemTaxes()
        {
            var response = await _invoiceItemTaxService.GetAllInvoiceItemTaxes();
            return Ok(response);
        }

        [HttpPost("createinvoiceitemtax")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(
            Summary = "Creates new invoiceitemtax.",
            Description = "Creates new invoiceitemtax.",
            OperationId = "InvoiceItemTaxesController.CreateInvoiceItemTax")]
        public async Task<ActionResult<CreateInvoiceItemTaxResponse>> CreateInvoiceItemTax(CreateInvoiceItemTaxRequest request)
        {
            var response = await _invoiceItemTaxService.CreateInvoiceItemTaxAsync(request);
            return Created($"/{response.Id}", response);
        }

        [HttpPut("updateinvoiceitemtax")]
        [SwaggerOperation(
            Summary = "Updates invoiceitemtax info.",
            Description = "Updates info in invoiceitemtax that already exists.",
            OperationId = "InvoiceItemTaxesController.UpdateInvoiceItemTax")]
        public async Task<UpdateInvoiceItemTaxResponse> UpdateInvoiceItemTax(UpdateInvoiceItemTaxRequest? request)
        {
            var response = await _invoiceItemTaxService.UpdateInvoiceItemTaxAsync(request);
            return response;
        }

        [HttpDelete("deleteinvoiceitemtax{invoiceitemtaxId}")]
        [SwaggerOperation(
            Summary = "Deletes invoiceitemtax.",
            Description = "Deletes all info about invoiceitemtax and remove it.",
            OperationId = "InvoiceItemTaxesController.DeleteInvoiceItemTax")]
        public async Task<ActionResult> DeleteInvoiceItemTax(int invoiceitemtaxId)
        {
            await _invoiceItemTaxService.DeleteInvoiceItemTaxAsync(invoiceitemtaxId);
            return NoContent();
        }
    }
}
