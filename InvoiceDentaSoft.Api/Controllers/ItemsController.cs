using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Requests.Items;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.Items;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Services;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InvoiceDentaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>Get all Items.</summary>
        /// <param name="request">The request.</param>
        /// <returns>return OkResponse</returns>
        [HttpGet("allitems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Give a list of all Items",
            Description = "Returns the List of Items",
            OperationId = "ItemsController.GetAllItems")
        ]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
        {
            var response = await _itemService.GetAllItemsAsync();
            return Ok(response);
        }

        /// <summary>Creates the Item.</summary>
        /// <param name="request">The request.</param>
        /// <returns>return CreateItemResponse</returns>
        [HttpPost("createitem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(
            Summary = "Creates new item.",
            Description = "Creates new item.",
            OperationId = "ItemsController.CreateItem")]
        public async Task<ActionResult<CreateItemResponse>> CreateItem(CreateItemRequest request)
        {
            var response = await _itemService.CreateItemAsync(request);
            return Created($"/{response.Id}", response);
        }

        /// <summary>Updates the specified request.</summary>
        /// <param name="request">The request.</param>
        /// <param name="Id">The Item identifier.</param>
        /// <returns>return UpdateItemResponse</returns>
        [HttpPut("updateitem")]
        [SwaggerOperation(
            Summary = "Updates item info.",
            Description = "Updates info in item that already exists.",
            OperationId = "ItemsController.UpdateItem")]
        public async Task<ActionResult<UpdateItemResponse>> UpdateItem(UpdateItemRequest? request)
        {
            var response = await _itemService.UpdateItemAsync(request);
            return Ok(response);
        }

        /// <summary>Deletes the item identifier.</summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>return NoContent</returns>
        [HttpDelete("deleteitem{itemId}")]
        [SwaggerOperation(
            Summary = "Deletes item.",
            Description = "Deletes all info about item and remove it.",
            OperationId = "ItemsController.DeleteItem")]
        public async Task<ActionResult> DeleteItem(int itemId)
        {
            await _itemService.DeleteItemAsync(itemId);
            return NoContent();
        }
    }
}
