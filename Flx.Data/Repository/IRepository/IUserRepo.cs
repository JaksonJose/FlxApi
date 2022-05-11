using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
using Flx.Domain.Responses;
using Flx.Shared.Requests;

namespace Flx.Data.Repository.IRepository
{
    public interface IUserRepo
    {
        public Task<UserInquiryResponse> FetchUserByEmail(ModelOperationRequest<SignIn> request);
        public Task<List<User>> FetchAllUsers();
        public Task<UserInquiryResponse> InsertUserAsync(ModelOperationRequest<User> request);
    }
}
