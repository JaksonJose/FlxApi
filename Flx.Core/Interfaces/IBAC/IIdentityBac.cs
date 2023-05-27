using Flx.Core.Identity.models;
using Flx.Core.Identity.Models;
using Flx.Core.Responses;

namespace Flx.Core.Interfaces.IBAC
{
    public interface IIdentityBac
    {
        public Task<UserInquiryResponse> AuthUserBacAsync(SignIn auth);

        public Task<UserInquiryResponse> RegisterCredentialBacAsync(Register userRegister);
    }
}
