using Flx.Domain.Domains;
using Flx.Domain.IValidators;
using Flx.Domain.Responses;

namespace Flx.Domain.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        public InquiryResponse<Category> ValidateCategoryList(List<Category> categoryList)
        {
            InquiryResponse<Category> categoryListResponse = new();

            if (!categoryList.Any())
            {
                categoryListResponse.Messages.Add("Category is null");
            }

            // Must to validate Subcategories, Courses and etc... 

            return categoryListResponse;
        }   
    }
}
