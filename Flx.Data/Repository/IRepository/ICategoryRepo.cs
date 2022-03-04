using Flx.Domain.Domains;
using Flx.Domain.Responses;

namespace Flx.Data.Repository.IRepository
{
    public interface ICategoryRepo
    {
        public Task<InquiryResponse<Category>> FetchAllCategoriesAsync();

        public Task<InquiryResponse<Category>> FetchCategoryByIdAsync(long categoryId);
    }
}
