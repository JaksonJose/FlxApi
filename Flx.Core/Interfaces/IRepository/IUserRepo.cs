using Flx.Core.Identity.Models;
using Flx.Core.Models;
using Flx.Core.Responses;
using Flx.Shared.Requests;

namespace Flx.Core.Interfaces.IRepository
{
    public interface IUserRepo
    {
        public Task<UserInquiryResponse> FetchUserByEmailAsync(ModelOperationRequest<User> request);

        public Task<List<User>> FetchAllUsersAsync();

        public Task<UserInquiryResponse> InsertUserAsync(ModelOperationRequest<User> request);
    }
}
