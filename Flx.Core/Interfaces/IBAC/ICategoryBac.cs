using Flx.Core.Models;
using Flx.Core.Responses;
using Flx.Shared.Responses;

namespace Flx.Core.Interfaces.IBAC
{
    public interface ICategoryBac
    {
        public Task<CategoryInquiryResponse> FetchAllCategoriesAsync();

        public Task<CategoryInquiryResponse> FetchCategoryByIdAsync(long id);

        public Task<ModelOperationResponse> InsertCategory(Category category);
    }
}
