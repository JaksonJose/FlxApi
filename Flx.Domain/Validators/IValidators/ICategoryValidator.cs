using Flx.Domain.Domains;

namespace Flx.Domain.IValidators
{
    public interface ICategoryValidator
    {
        public bool InErrorResponse(List<Category> response);
    }
}
