using Flx.Core.Models;
using Flx.Core.Interfaces.IBAC;
using Flx.Core.Interfaces.IRepository;
using Flx.Core.IValidators;
using Flx.Core.Responses;
using Flx.Shared.Requests;
using Flx.Shared.Responses;

namespace Flx.Core.BAC
{
    public class CategoryBac : ICategoryBac
    {   
        private readonly ICategoryValidator _categoryValidator;
        private readonly ICategoryRepo _categoryRepo;

        public CategoryBac(ICategoryValidator categoryValidator, ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _categoryValidator = categoryValidator;
        }

        /// <summary>
        /// Fetch all Categories
        /// </summary>
        /// <returns></returns>
        public async Task<CategoryInquiryResponse> FetchAllCategoriesAsync()
        {
            CategoryInquiryResponse response = await _categoryRepo.FindByRequestAsync();

            return response;
        }

        /// <summary>
        /// Fetch Category by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CategoryInquiryResponse> FetchCategoryByIdAsync(long id)
        {
            CategoryInquiryResponse response = await _categoryRepo.FetchCategoryByIdAsync(id);

            return response;
        }

        /// <summary>
        /// Insert a Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<ModelOperationResponse> InsertCategory(Category category)
        {
            ModelOperationRequest<Category> request = new(category);

            ModelOperationResponse response = _categoryValidator.ValidateCategory(category);
            if (response.HasErrorMessages)
            {
                return response;
            }

            response = await _categoryRepo.InsertCategoryAsync(request, response);

            return response;
        }
    }
}
