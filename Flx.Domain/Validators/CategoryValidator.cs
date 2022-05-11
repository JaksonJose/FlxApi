using Flx.Domain.Domains;
using Flx.Domain.IValidators;
using Flx.Domain.Responses;
using Microsoft.AspNetCore.Http;

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
                return response;
            }

            if (string.IsNullOrEmpty(category.Name))
            {
                response.AddErrorMessage("Category Name is required");
            }
            
            if (string.IsNullOrEmpty(category.Description))
            {
                response.AddWarningMessage("Category Description is empty");
            }

            return response;
        }   
    }
}
