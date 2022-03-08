using Flx.Domain.Domains;
using Flx.Domain.Responses;

namespace Flx.Data.Repository.IRepository
{
    public interface ICategoryRepo
    {
        public Task<CategoryInquiryResponse> FetchAllCategoriesAsync();

        public Task<CategoryInquiryResponse> FetchCategoryByIdAsync(long categoryId);
    }
}
