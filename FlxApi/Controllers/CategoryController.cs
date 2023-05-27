using Flx.Api.Controllers;
using Flx.Core.Interfaces.IBAC;
using Flx.Core.Models;
using Flx.Core.Responses;
using Flx.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FlxApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryBac _categoryBac;

        public CategoryController(ICategoryBac categoryBac, ILogger<CategoryController> logger)
        {
            _logger = logger;
            _categoryBac = categoryBac;
        }

        [HttpGet]
        public async Task<ActionResult> FetchAllCategories()
        {
            CategoryInquiryResponse response = await _categoryBac.FetchAllCategoriesAsync();
            if(response.HasErrorMessages)
            {
                BadRequest(response);
            }

            _logger.LogInformation("Categories was successfully fetched.");

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FetchCategoryByIdAsync(long id)
        {
            CategoryInquiryResponse response = await _categoryBac.FetchCategoryByIdAsync(id);
            if(response.HasErrorMessages)
            {
                BadRequest(response);
            }

            _logger.LogInformation("Category by Id was successfully");

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> InsertCategoryAsync([FromBody] Category category)
        {
            ModelOperationResponse response = await _categoryBac.InsertCategoryAsync(category);
            if (response.HasErrorMessages) 
            { 
                return BadRequest(response); 
            }           

            response.AddInfoMessage("Category Created", StatusCodes.Status201Created);

            return Ok(response);   
        }
    }
}