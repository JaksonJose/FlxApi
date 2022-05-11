using Flx.Api.Controllers;
using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
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
        public async Task<ActionResult> GetAllCategories()
        {
            CategoryInquiryResponse response = await _categoryRepo.FetchAllCategoriesAsync();

            _logger.LogInformation("Categories was successfully fetched.");

            return Ok(response.ResponseData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryByIdAsync(long id)
        {
            CategoryInquiryResponse response = await _categoryRepo.FetchCategoryByIdAsync(id);

            _logger.LogInformation("Category by Id was successfully");

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> InsertCategoryAsync([FromBody] Category category)
        {
            ModelOperationRequest<Category> request = new(category);

            CategoryInquiryResponse response = _categoryBac.InsertCategoryBac(request);

            if (response.HasErrorMessages)
            {
                return BadRequest(response);
            }

            response = await _categoryRepo.InsertCategoryAsync(request, response);     

            return Ok(response);   
        }
    }
}