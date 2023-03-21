using InvoiceDentaSoft.Api.Dto_s.Requests.Items;
using InvoiceDentaSoft.Api.Dto_s.Requests.Taxes;
using InvoiceDentaSoft.Api.Dto_s.Responses.Items;
using InvoiceDentaSoft.Api.Dto_s.Responses.Taxes;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Services;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InvoiceDentaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private readonly ITaxService _service;

        public TaxesController(ITaxService service)
        {
            _service = service;
        }

        /// <summary>Get all Taxes.</summary>
        /// <param name="request">The request.</param>
        /// <returns>return OkResponse</returns>
        [HttpGet("alltaxes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Give a list of all Taxes",
            Description = "Returns the List of Taxes",
            OperationId = "TaxesController.GetAllTaxes")
        ]
        public async Task<ActionResult<IEnumerable<Tax>>> GetAllTaxes()
        {
            var response = await _service.GetAllTaxes();
            return Ok(response);
        }

        /// <summary>Creates the Tax.</summary>
        /// <param name="request">The request.</param>
        /// <returns>return CreateTaxResponse</returns>
        [HttpPost("createtax")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(
            Summary = "Creates new tax.",
            Description = "Creates new tax.",
            OperationId = "TaxesController.CreateTax")]
        public async Task<ActionResult<CreateTaxResponse>> CreateTax(CreateTaxRequest request)
        {
            var response = await _service.CreateTaxAsync(request);
            return Created($"/{response.Id}", response);
        }

        /// <summary>Updates the specified request.</summary>
        /// <param name="request">The request.</param>
        /// <param name="Id">The Tax identifier.</param>
        /// <returns>return UpdateTaxResponse</returns>
        [HttpPut("updatetax")]
        [SwaggerOperation(
            Summary = "Updates tax info.",
            Description = "Updates info in tax that already exists.",
            OperationId = "TaxesController.UpdateTax")]
        public async Task<ActionResult<UpdateTaxResponse>> UpdateTax(UpdateTaxRequest? request)
        {
            var response = await _service.UpdateTaxAsync(request);
            return Ok(response);
        }

        /// <summary>Deletes the Tax identifier.</summary>
        /// <param name="taxId">The Tax identifier.</param>
        /// <returns>return NoContent</returns>
        [HttpDelete("deletetax{taxId}")]
        [SwaggerOperation(
            Summary = "Deletes tax.",
            Description = "Deletes all info about tax and remove it.",
            OperationId = "TaxesController.DeleteTax")]
        public async Task<ActionResult> DeleteTax(int taxId)
        {
            await _service.DeleteTaxAsync(taxId);
            return NoContent();
        }
    }
}
