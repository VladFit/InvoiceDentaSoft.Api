using InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceTotal;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceTotal;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InvoiceDentaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceTotalController : ControllerBase
    {
        private readonly IInvoiceTotalService _invoiceTotalService;

        public InvoiceTotalController(IInvoiceTotalService invoiceTotalService)
        {
            _invoiceTotalService = invoiceTotalService;
        }

        [HttpGet("allinvoicetotals")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Give a list of all InvoiceTotals",
            Description = "Returns the List of InvoiceTotals",
            OperationId = "InvoiceTotalsController.GetAllInvoiceTotals")
        ]
        public async Task<ActionResult<IEnumerable<InvoiceTotal>>> GetAllInvoiceTotals()
        {
            var response = await _invoiceTotalService.GetAllInvoiceTotals();
            return Ok(response);
        }

        [HttpPost("createinvoicetotal")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(
            Summary = "Creates new InvoiceTotal.",
            Description = "Creates new InvoiceTotal.",
            OperationId = "InvoiceTotalController.CreateInvoiceTotal")]
        public async Task<ActionResult<CreateCategoryResponse>> CreateCategory(CreateInvoiceTotalRequest request)
        {
            var response = await _invoiceTotalService.CreateInvoiceTotalAsync(request);
            return Created($"/{response.Id}", response);
        }

        [HttpPut("updateinvoicetotal")]
        [SwaggerOperation(
            Summary = "Updates InvoiceTotal info.",
            Description = "Updates info in InvoiceTotal that already exists.",
            OperationId = "InvoiceTotalController.UpdateInvoiceTotal")]
        public async Task<UpdateInvoiceTotalResponse> UpdateInvoiceTotal(UpdateInvoiceTotalRequest? request)
        {
            var response = await _invoiceTotalService.UpdateInvoiceTotalAsync(request);
            return response;
        }

        [HttpDelete("deleteinvoicetotal{invoicetotalId}")]
        [SwaggerOperation(
            Summary = "Deletes InvoiceTotal.",
            Description = "Deletes all info about InvoiceTotal and remove it.",
            OperationId = "InvoiceTotalController.DeleteInvoiceTotal")]
        public async Task<ActionResult> DeleteInvoiceTotal(int invoicetotalId)
        {
            await _invoiceTotalService.DeleteInvoiceTotalAsync(invoicetotalId);
            return NoContent();
        }
    }
}
