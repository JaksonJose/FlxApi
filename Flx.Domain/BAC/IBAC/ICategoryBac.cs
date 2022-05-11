using Flx.Domain.Domains;
using Flx.Shared.Requests;
using Flx.Shared.Responses;

namespace Flx.Domain.BAC.IBAC
{
    public interface ICategoryBac
    {
        public ModelOperationResponse InsertCategoryBac(Category category);
    }
}
