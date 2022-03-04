using Flx.Domain.Domains;
using Flx.Domain.IValidators;

namespace Flx.Domain.Validators
{
    public class CategoryValidator : ICategoryValidator
    {   
        public bool InErrorResponse(List<Category> response)
        {
            bool inError = false;

            if (!response.Any())
            {
                inError = true;
            }

            return inError;
        }
    }
}
