using Flx.Domain.Domains;
using Flx.Domain.IValidators;
using Flx.Domain.Responses;

namespace Flx.Domain.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        public CategoryInquiryResponse ValidateCategory(Category category)
        {
            CategoryInquiryResponse response = new();
            
            if (category == null)
            {
                response.AddErrorMessage("Category can't be null");
            }

            if (category.Name == null || category.Name == "")
            {
                response.AddErrorMessage("Category must have a name");
            }           

            return response;
        }   
    }
}
