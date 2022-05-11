using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.IValidators;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
using Flx.Shared.Responses;

namespace Flx.Domain.BAC
{
    public class CategoryBac : ICategoryBac
    {   
        private readonly ICategoryValidator _categoryValidator;
        public CategoryBac(ICategoryValidator categoryValidator)
        {
            _categoryValidator = categoryValidator;
        }

        public ModelOperationResponse InsertCategoryBac(Category category)
        {
            ModelOperationResponse response = _categoryValidator.ValidateCategory(category);
            if (response.HasErrorMessages)
            {
                return response;
            }

            return response;
        }
    }
}
