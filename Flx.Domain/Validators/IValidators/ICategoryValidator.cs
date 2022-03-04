using Flx.Domain.Domains;

namespace Flx.Domain.IValidators
{
    public interface ICategoryValidator
    {
        public string ValidateCategoryList(List<Category> category);
    }
}
