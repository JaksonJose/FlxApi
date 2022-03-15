using Flx.Api.Controllers;
using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlxApi.Controllers
{
    [ApiController]
    [Route("api/category")]
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
        [AllowAnonymous]
        public async Task<List<Category>> GetAllCategories()
        {
            CategoryInquiryResponse response = new();

            try
            {
                 response = await _categoryRepo.FetchAllCategoriesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to loggin {ex.Message}");

                response.AddExceptionMessage("Error while trying to fetch all Categories", StatusCodes.Status500InternalServerError);
            }

            return response.ResponseData;
        }

        [HttpGet("{id}")]
        public async Task<Category> GetCategoryByIdAsync(long id)
        {
            CategoryInquiryResponse response = new();

            try
            {
                response = await _categoryRepo.FetchCategoryByIdAsync(id);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error while trying to loggin {ex.Message}");

                response.AddExceptionMessage("Error while trying to fetch Category by Id", StatusCodes.Status500InternalServerError);
            }                     

            return response.ResponseData.FirstOrDefault();
        }

        [HttpPost]
        public async Task<CategoryInquiryResponse> InsertCategoryAsync([FromBody] Category category)
        {
            ModelOperationRequest<Category> request = new(category);

            CategoryInquiryResponse response = _categoryBac.InsertCategoryBac(request);

            if (response.HasErrorMessages)
            {
                return response;
            }

            try
            {
                response = await _categoryRepo.InsertCategoryAsync(request, response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to loggin {ex.Message}");

                response.AddExceptionMessage("Error while trying to insert a Category", StatusCodes.Status500InternalServerError);

                return response;
            }

            return response;   
        }
    }
}
