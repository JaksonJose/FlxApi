using Flx.Domain.BAC.IBAC;
using Flx.Domain.Domains;
using Flx.Domain.IValidators;

namespace Flx.Domain.BAC
{
    public class CategoryBac : ICategoryBac
    {   
        private readonly ICategoryValidator _categoryValidator;
        public CategoryBac(ICategoryValidator categoryValidator)
        {
            this._categoryValidator = categoryValidator;
        }
        public List<Category> CategoryList(List<Category> category)
        {
            //var response = _categoryValidator.ValidateCategoryList(category);

            return category;
        }    
    }
}
