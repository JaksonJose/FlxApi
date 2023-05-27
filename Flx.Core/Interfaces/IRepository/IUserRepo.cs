using Flx.Core.Identity.Models;
using Flx.Core.Models;
using Flx.Core.Responses;
using Flx.Shared.Requests;

namespace Flx.Core.Interfaces.IRepository
{
    public interface IUserRepo
    {
        public Task<UserInquiryResponse> FetchUserByEmail(ModelOperationRequest<User> request);

        public Task<List<User>> FetchAllUsers();

        public Task<UserInquiryResponse> InsertUserAsync(ModelOperationRequest<User> request);
    }
}
