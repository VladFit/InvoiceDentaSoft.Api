using InvoiceDentaSoft.Api.Dto_s.Requests.Category;
using InvoiceDentaSoft.Api.Dto_s.Responses.Category;
using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InvoiceDentaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>Get all Categories.</summary>
        /// <param name="request">The request.</param>
        /// <returns>return OkResponse</returns>
        [HttpGet("allcategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Give a list of all Categories",
            Description = "Returns the List of Categories",
            OperationId = "CategoriesController.GetAllCategories")
        ]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var response = await _categoryService.GetAllCategories();
            return Ok(response);
        }

        /// <summary>Creates the Category.</summary>
        /// <param name="request">The request.</param>
        /// <returns>return CreateCategoryResponse</returns>
        [HttpPost("createcategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation(
            Summary = "Creates new category.",
            Description = "Creates new category.",
            OperationId = "CategoriesController.CreateCategory")]
        public async Task<ActionResult<CreateCategoryResponse>> CreateCategory(CreateCategoryRequest request)
        {
            var response = await _categoryService.CreateCategoryAsync(request);
            return Created($"/{response.Id}", response);
        }

        /// <summary>Updates the specified request.</summary>
        /// <param name="request">The request.</param>
        /// <param name="Id">The category identifier.</param>
        /// <returns>return UpdateCategoryResponse</returns>
        [HttpPut("updatecategory")]
        [SwaggerOperation(
            Summary = "Updates category info.",
            Description = "Updates info in category that already exists.",
            OperationId = "CategoriesController.UpdateCategory")]
        public async Task<ActionResult<UpdateCategoryResponse>> UpdateCategory(UpdateCategoryRequest? request)
        {
            var response = await _categoryService.UpdateCategoryAsync(request);
            return Ok(response);
        }

        /// <summary>Deletes the category identifier.</summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>return NoContent</returns>
        [HttpDelete("deletecategory{categoryId}")]
        [SwaggerOperation(
            Summary = "Deletes category.",
            Description = "Deletes all info about category and remove it.",
            OperationId = "CategoriesController.DeleteCategory")]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            await _categoryService.DeleteCategoryAsync(categoryId);
            return NoContent();
        }
    }
}
