using Flx.Data.Repository.IRepository;
using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
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
        public List<Category> GetAllCategories()
        {
            List<Category> response = _categoryRepo.FetchAllCategories();
            List<Category> category = _categoryBac.CategoryList(response);

            return category;
        }

        [HttpGet("{id}")]
        public async Task<Category> GetCategoryByIdAsync(long id)
        {
            Category response = await _categoryRepo.FetchCategoryByIdAsync(id);
            

            return response;
        }
    }
}
