using Flx.Domain.Models;
using Flx.Domain.Responses;
using Flx.Shared.Requests;
using Flx.Shared.Responses;

namespace Flx.Data.Repository.IRepository
{
    public interface IUserRepo
    {
        public Task<UserInquiryResponse> InsertUserAsync(ModelOperationRequest<User> request);
    }
}
