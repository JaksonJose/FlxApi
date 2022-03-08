using Flx.Domain.Domains;
using Flx.Domain.Responses;
using Flx.Shared.Requests;

namespace Flx.Domain.BAC.IBAC
{
    public interface ICategoryBac
    {
        public CategoryInquiryResponse InsertCategoryBac(ModelOperationRequest<Category> category);
    }
}
