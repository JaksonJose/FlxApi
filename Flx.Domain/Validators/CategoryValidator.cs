using Flx.Domain.Domains;
using Flx.Domain.IValidators;
using Flx.Domain.Responses;

namespace Flx.Domain.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        public CategoryInquiryResponse ValidateCategoryList(List<Category> categoryList)
        {
            CategoryInquiryResponse categoryListResponse = new();    

            // Must to validate Subcategories, Courses and etc... 

            return categoryListResponse;
        }   
    }
}
