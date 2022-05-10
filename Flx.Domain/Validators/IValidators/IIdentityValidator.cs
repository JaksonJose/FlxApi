using Flx.Domain.Identity.Models;
using Flx.Domain.Models;
using Flx.Domain.Responses;

namespace Flx.Domain.Validators.IValidators
{
    public interface IIdentityValidator
    {
        public bool AuthCredentialsValidation(Auth auth);

        public UserInquiryResponse UserAuthenticationValidation(Auth auth, UserInquiryResponse user);
    }
}
