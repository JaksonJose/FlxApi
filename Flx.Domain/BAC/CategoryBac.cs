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
        public InquiryResponse<Category> CategoryList(IEnumerable<Category> categoryList)
        {
            InquiryResponse<Category> response = new();
            List<Category> categories = categoryList.ToList();

            this._categoryValidator.ValidateCategoryList(categories);

            response.ResponseData = categories;

            return response;
        }    
    }
}
