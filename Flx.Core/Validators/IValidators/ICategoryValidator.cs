using Flx.Core.Models;
using Flx.Shared.Responses;

namespace Flx.Core.IValidators
{
    public interface ICategoryValidator
    {
        public ModelOperationResponse  ValidateCategory(Category category);
    }
}
