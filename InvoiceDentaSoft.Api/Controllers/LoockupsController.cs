using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Entities.LoockUps;
using InvoiceDentaSoft.Api.Service.Repositories.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InvoiceDentaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoockupsController : ControllerBase
    {
        private readonly IGenericRepository<VendorType> _genericRepository;

        public LoockupsController(IGenericRepository<VendorType> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        /// <summary>Get all VendorType.</summary>
        /// <param name="request">The request.</param>
        /// <returns>return OkResponse</returns>
        [HttpGet("allvendortype")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Give a list of all VendorType",
            Description = "Returns the List of VendorType",
            OperationId = "LoockupsController.GetAllVendorType")
        ]
        public async Task<ActionResult<IEnumerable<VendorType>>> GetAllVendorType()
        {
            var response = _genericRepository.GetAll();
            return Ok(response);
        }
    }
}
