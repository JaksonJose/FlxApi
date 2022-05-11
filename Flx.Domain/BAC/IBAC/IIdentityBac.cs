using Flx.Domain.Identity.models;
using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
using Flx.Domain.Responses;


namespace Flx.Domain.BAC.IBAC
{
    public interface IIdentityBac
    {
        public UserInquiryResponse AuthUserBac(SignIn auth, UserInquiryResponse userResponse);
        public UserInquiryResponse RegisterCredentialBac(Register userRegister, List<User> userList);
    }
}