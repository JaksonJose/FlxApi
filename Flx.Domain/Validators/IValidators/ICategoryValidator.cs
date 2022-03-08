using Flx.Domain.Domains;
using Flx.Domain.Responses;

namespace Flx.Domain.IValidators
{
    public interface ICategoryValidator
    {
        public CategoryInquiryResponse ValidateCategoryList(List<Category> category);
    }
}
