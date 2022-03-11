using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.IValidators;
using Flx.Domain.Responses;
using Flx.Shared.Requests;

namespace Flx.Domain.BAC
{
    public class CategoryBac : ICategoryBac
    {   
        private readonly ICategoryValidator _categoryValidator;
        public CategoryBac(ICategoryValidator categoryValidator)
        {
            this._categoryValidator = categoryValidator;
        }

        public CategoryInquiryResponse InsertCategoryBac(ModelOperationRequest<Category> request)
        {
            CategoryInquiryResponse response = this._categoryValidator.ValidateCategory(request.Model);

            return response;
        }
    }
}
