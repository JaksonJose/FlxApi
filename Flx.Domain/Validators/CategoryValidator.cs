using Flx.Domain.Domains;
using Flx.Domain.IValidators;

namespace Flx.Domain.Validators
{
    public class CategoryValidator : ICategoryValidator
    {   
        public string ValidateCategoryList(List<Category> category)
        {
            if (category.Any() && category.Count > 0)
            {
                return "The Category is not null";
            }

            return "Categoies Can't be null";
        }
    }
}
