using Flx.Domain.Domains;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
using Flx.Shared.Responses;

namespace Flx.Domain.Interfaces.IRepository
{
    public interface ICategoryRepo
    {
        public Task<CategoryInquiryResponse> FindByRequestAsync();

        public Task<CategoryInquiryResponse> FetchCategoryByIdAsync(long categoryId);

        public Task<ModelOperationResponse> InsertCategoryAsync(ModelOperationRequest<Category> category, ModelOperationResponse response);
    }
}
