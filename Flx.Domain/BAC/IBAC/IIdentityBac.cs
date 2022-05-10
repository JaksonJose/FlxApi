using Flx.Domain.Identity.Models;
using Flx.Domain.Responses;


namespace Flx.Domain.BAC.IBAC
{
    public interface IIdentityBac
    {
        public UserInquiryResponse AuthUserBac(Auth auth, UserInquiryResponse userResponse);
        public UserInquiryResponse RegisterCredentialBac(Auth auth);
    }
}
