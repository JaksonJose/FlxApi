using Flx.Domain.Domains;
using Flx.Domain.Responses;
using Flx.Shared.Requests;

namespace Flx.Data.Repository.IRepository
{
    public interface ICategoryRepo
    {
        public Task<CategoryInquiryResponse> InsertCategoryAsync(ModelOperationRequest<Category> category, CategoryInquiryResponse response);
        public Task<CategoryInquiryResponse> FetchAllCategoriesAsync();
        public Task<CategoryInquiryResponse> FetchCategoryByIdAsync(long categoryId);
    }
}
