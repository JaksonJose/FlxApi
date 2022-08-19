using Flx.Domain.Identity.models;
using Flx.Domain.Identity.Models;
using Flx.Domain.Responses;

namespace Flx.Domain.Interfaces.IBAC
{
    public interface IIdentityBac
    {
        public Task<UserInquiryResponse> AuthUserBac(SignIn auth);

        public Task<UserInquiryResponse> RegisterCredentialBac(Register userRegister);
    }
}
