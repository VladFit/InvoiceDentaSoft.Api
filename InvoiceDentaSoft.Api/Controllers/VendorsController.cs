using InvoiceDentaSoft.Api.Dto_s.Requests.Taxes;
using InvoiceDentaSoft.Api.Dto_s.Requests.Vendors;
using InvoiceDentaSoft.Api.Dto_s.Responses.Taxes;
using InvoiceDentaSoft.Api.Dto_s.Responses.Vendors;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InvoiceDentaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorsController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        /// <summary>Get all Taxes.</summary>
        /// <param name="request">The request.</param>
        /// <returns>return OkResponse</returns>
        [HttpGet("allvendor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Give a list of all Vendors",
            Description = "Returns the List of Vendors",
            OperationId = "VendorsController.GetAllVendors")
        ]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetAllVendors()
        {
            var response = await _vendorService.GetAllVendors();
            return Ok(response);
        }

        /// <summary>Creates the Vendor.</summary>
        /// <param name="request">The request.</param>
        /// <returns>return CreateVendorResponse</returns>
        [HttpPost("createvendor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(
            Summary = "Creates new vendor.",
            Description = "Creates new vendor.",
            OperationId = "VendorsController.CreateVendor")]
        public async Task<ActionResult<CreateVendorResponse>> CreateVendor(CreateVendorRequest request)
        {
            var response = await _vendorService.CreateVendorAsync(request);
            return Created($"/{response.Id}", response);
        }

        /// <summary>Updates the specified request.</summary>
        /// <param name="request">The request.</param>
        /// <param name="Id">The vendor identifier.</param>
        /// <returns>return UpdateVendorResponse</returns>
        [HttpPut("updatevendor")]
        [SwaggerOperation(
            Summary = "Updates vendor info.",
            Description = "Updates info in vendor that already exists.",
            OperationId = "VendorsController.UpdateVendor")]
        public async Task<ActionResult<UpdateVendorResponse>> UpdateVendor(UpdateVendorRequest? request)
        {
            var response = await _vendorService.UpdateVendorAsync(request);
            return Ok(response);
        }

        /// <summary>Deletes the Vendor identifier.</summary>
        /// <param name="vendorId">The Vendor identifier.</param>
        /// <returns>return NoContent</returns>
        [HttpDelete("deletevendor{vendorId}")]
        [SwaggerOperation(
            Summary = "Deletes vendor.",
            Description = "Deletes all info about vendor and remove it.",
            OperationId = "VendorsController.DeleteVendor")]
        public async Task<ActionResult> DeleteVendor(int vendorId)
        {
            await _vendorService.DeleteVendorAsync(vendorId);
            return NoContent();
        }
    }
}
