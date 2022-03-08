using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FlxApi.Controllers
{
    [Controller]
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly ICategoryBac _categoryBac;

        public CategoryController(ICategoryRepo categoryRepo, ICategoryBac categoryBac)
        {
            _categoryRepo = categoryRepo;
            _categoryBac = categoryBac;
        }

        [HttpGet]
        public async Task<List<Category>> GetAllCategories()
        {
            CategoryInquiryResponse response = await _categoryRepo.FetchAllCategoriesAsync();

            return response.ResponseData;
        }

        [HttpGet("{id}")]
        public async Task<Category> GetCategoryByIdAsync(long id)
        {
            CategoryInquiryResponse response = await _categoryRepo.FetchCategoryByIdAsync(id);            

            return response.ResponseData.FirstOrDefault();
        }

        [HttpPost]
        public async Task CreateCategory([FromBody] Category category)
        {
            CategoryInquiryResponse response = _categoryBac.InsertCategoryBac(category);

            if (response.HasAnyMessages)
            {
                return;
            }

            await _categoryRepo.InsertCategory(category);
        }
    }
}
