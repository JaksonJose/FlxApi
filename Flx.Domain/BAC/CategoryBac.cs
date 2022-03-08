using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.IValidators;
using Flx.Domain.Responses;

namespace Flx.Domain.BAC
{
    public class CategoryBac : ICategoryBac
    {   
        private readonly ICategoryValidator _categoryValidator;
        public CategoryBac(ICategoryValidator categoryValidator)
        {
            this._categoryValidator = categoryValidator;
        }

        public CategoryInquiryResponse InsertCategoryBac(Category category)
        {
            CategoryInquiryResponse response = new();

            response = this._categoryValidator.ValidateCategory(category);

            if (response.HasAnyMessages)
            {
                return response;
            }

            response.ResponseData.Add(category);

            return response;
        }
    }
}
