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
                response.AddErrorMessage("Category Name is required");
            }
            
            if (category.Description == null || category.Description == "")
            {
                response.AddWarningMessage("Category Description is empty");
            }

            return response;
        }   
    }
}
