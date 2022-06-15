using Flx.Api.Controllers;
using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
using Flx.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FlxApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryRepo _categoryRepo;
        private readonly ICategoryBac _categoryBac;

        public CategoryController(ICategoryRepo categoryRepo, ICategoryBac categoryBac, ILogger<CategoryController> logger)
        {
            _logger = logger;
            _categoryRepo = categoryRepo;
            _categoryBac = categoryBac;
        }

        [HttpGet]
        public async Task<ActionResult> FetchAllCategories()
        {
            CategoryInquiryResponse response = await _categoryRepo.FindByRequestAsync();

            _logger.LogInformation("Categories was successfully fetched.");

            return Ok(response.ResponseData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FetchCategoryByIdAsync(long id)
        {
            CategoryInquiryResponse response = await _categoryRepo.FetchCategoryByIdAsync(id);

            _logger.LogInformation("Category by Id was successfully");

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> InsertCategoryAsync([FromBody] Category category)
        {     
            
            ModelOperationResponse response = _categoryBac.InsertCategoryBac(category);
            if (response.HasErrorMessages) return BadRequest(response);            

            ModelOperationRequest<Category> request = new(category);

            response = await _categoryRepo.InsertCategoryAsync(request, response);
            if (response.HasExceptionMessages) return BadRequest(response);

            response.AddInfoMessage("Category Created", StatusCodes.Status201Created);

            return Ok(response);   
        }
    }
}