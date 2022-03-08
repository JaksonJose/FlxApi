using Flx.Domain.Domains;
using Flx.Domain.Responses;

namespace Flx.Domain.IValidators
{
    public interface ICategoryValidator
    {
        public CategoryInquiryResponse ValidateCategory(Category category);
    }
}
