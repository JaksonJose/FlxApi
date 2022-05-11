using Flx.Domain.Domains;
using Flx.Shared.Responses;

namespace Flx.Domain.IValidators
{
    public interface ICategoryValidator
    {
        public ModelOperationResponse  ValidateCategory(Category category);
    }
}
