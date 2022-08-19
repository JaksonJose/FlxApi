using Flx.Domain.Domains;
using Flx.Domain.Responses;
using Flx.Shared.Responses;

namespace Flx.Domain.Interfaces.IBAC
{
    public interface ICategoryBac
    {
        public Task<CategoryInquiryResponse> FetchAllCategoriesAsync();

        public Task<CategoryInquiryResponse> FetchCategoryByIdAsync(long id);

        public Task<ModelOperationResponse> InsertCategory(Category category);
    }
}
